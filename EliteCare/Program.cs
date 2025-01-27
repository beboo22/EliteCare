using EliteCare.Api.Mapper;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Infrastructure.Repository.impelementation;
using EliteCare.Service.Abstract;
using EliteCare.Service.impelementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EliteCare.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            builder.Services.AddScoped(typeof(IDoctorRepo), typeof(DoctorRepo));
            builder.Services.AddScoped(typeof(IDoctorService), typeof(DoctorService));
            builder.Services.AddAutoMapper(typeof(AtoMapper));

            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));







            var app = builder.Build();



            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();

            try
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");



                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }

        }
    }
}
