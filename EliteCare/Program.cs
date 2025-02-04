using EliteCare.Api.Mapper;
using EliteCare.Core.Features.Doctors.Commands.Handlers;
using EliteCare.Core.Features.Doctors.Queries.Handlers;
using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Data.DataSeeding;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Infrastructure.Repository.impelementation;
using EliteCare.Service.Abstract;
using EliteCare.Service.impelementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

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
            builder.Services.AddScoped(typeof(IGenrateService), typeof(GenrateService));
            builder.Services.AddScoped(typeof(ICachedService<>), typeof(CachedService<>));

            builder.Services.AddAutoMapper(typeof(AtoMapper));

            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DoctorQueryHandler).Assembly));
            
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(DoctorQueryHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(DoctorCommandHandler).Assembly);
            });


            builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
            {
                var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });




            var app = builder.Build();



            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            //try
            //{
            //    await context.Database.MigrateAsync();
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, "An error occurred while migrating the database.");
            //}



            // calling the seeding method


            //try
            //{
            //    await Seeding.SeedDataAsync(context, logger);
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, "An error occurred while seeding the database.");
            //}





            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
