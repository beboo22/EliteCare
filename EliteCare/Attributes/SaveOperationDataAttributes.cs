using AutoMapper;
using EliteCare.Core.BaseResponse;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class SaveOperationDataAttribute<T> : Attribute, IAsyncAuthorizationFilter, IAsyncActionFilter where T : BaseEntity
{
    public T Data { get; set; }


    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            // Enable request body buffering to allow multiple reads
            context.HttpContext.Request.EnableBuffering();

            // Check if the request has a body and is JSON
            if (context.HttpContext.Request.ContentType?.Contains("application/json") == true)
            {
                // Read the request body
                using (var reader = new StreamReader(
                    context.HttpContext.Request.Body,
                    Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: false,
                    bufferSize: 1024,
                    leaveOpen: true)) // Leave the stream open for further reads
                {
                    var requestBody = await reader.ReadToEndAsync();

                    if (!string.IsNullOrWhiteSpace(requestBody))
                    {
                        //var mapper = context.HttpContext.RequestServices.GetService<IMapper>();
                        // Deserialize the request body into the generic type T
                        Data = JsonSerializer.Deserialize<T>(requestBody, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true // Ensure case-insensitive property matching
                        });
                    }
                }

                // Reset the request body stream position for the next reader
                context.HttpContext.Request.Body.Position = 0;
            }
        }
        catch (Exception ex)
        {
            // Log the error (you can inject a logger if needed)
            var logger = context.HttpContext.RequestServices.GetService<ILogger<SaveOperationDataAttribute<T>>>();
            logger?.LogError(ex, "Error while reading request body.");

            // Return a 400 Bad Request response to the client
            context.Result = new BadRequestObjectResult("Invalid request body.");
        }
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var key = CreateKey(context.HttpContext);

        // Execute the action

        var cachedService = context.HttpContext.RequestServices.GetService<ICachedService<T>>();
        await cachedService.AddCachedData(key, Data);
        var executedContext = await next();
        // Check if the response is successful (200 OK)
        if (executedContext.Result is OkObjectResult okResult)
        {
            if (okResult.Value != null)
            {
                // Serialize the response data
                try
                {

                    var data = okResult.Value as ApiResultResponse<string>;

                    // Cache the data using the generated key
                    if (cachedService != null)
                    {
                        if (data != null && data.statusCode != 200)
                            await cachedService.RemoveCachedData(key);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

    private string CreateKey(HttpContext httpContext)
    {
        var cacheKey = new StringBuilder();

        // Extract email from JWT
        //var email = ExtractEmailFromJwt(httpContext);
        //cacheKey.Append(email).Append("_");

        // Append action name
        var actionName = httpContext.Request.RouteValues["action"]?.ToString();
        cacheKey.Append(actionName).Append("||");

        // Append current timestamp
        cacheKey.Append(DateTime.UtcNow);

        return cacheKey.ToString();
    }

    private string ExtractEmailFromJwt(HttpContext httpContext)
    {
        var authHeader = httpContext.Request.Headers["Authorization"].ToString();
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            return "anonymous";
        }

        var token = authHeader.Substring("Bearer ".Length).Trim();
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        // Extract email from the JWT claims
        var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
        return email ?? "anonymous";
    }
}