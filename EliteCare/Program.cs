using EliteCare.Api.Mapper;
using EliteCare.Core.Features.Appointments.Commands.Handlers;
using EliteCare.Core.Features.Appointments.Queries.Handlers;
using EliteCare.Core.Features.Authentications.Commands.Handlers;
using EliteCare.Core.Features.Authorizations.Commands.Handlers;
using EliteCare.Core.Features.Authorizations.Queries.Handlers;
using EliteCare.Core.Features.Bills.Commands.Handlers;
using EliteCare.Core.Features.Departments.Commands.Handlers;
using EliteCare.Core.Features.Departments.Queries.Handlers;
using EliteCare.Core.Features.Doctors.Commands.Handlers;
using EliteCare.Core.Features.Doctors.Queries.Handlers;
using EliteCare.Core.Features.Nurse.Queries.Handlers;
using EliteCare.Core.Features.Nurses.Commands.Handlers;
using EliteCare.Core.Features.patients.Queries.Handlers;
using EliteCare.Core.Features.Receptionists.Commands.Handlers;
using EliteCare.Core.Features.Receptionists.Queries.Handlers;
using EliteCare.Core.Features.SpecialistDoctorInDepartments.Commands.Handlers;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Data.DataSeeding;
using EliteCare.Infrastructure.IdentityData;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Infrastructure.Repository.impelementation;
using EliteCare.Service.Abstract;
using EliteCare.Service.impelementation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using X.Paymob.CashIn;

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


            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

            builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options=>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-@.";
            })
                            .AddEntityFrameworkStores<AppIdentityDbContext>()
                            .AddDefaultTokenProviders();


            builder.Services.AddScoped(typeof(IDoctorRepo), typeof(DoctorRepo));
            builder.Services.AddScoped(typeof(IDoctorService), typeof(DoctorService));

            builder.Services.AddScoped(typeof(INurseRepo), typeof(NurseRepo));
            builder.Services.AddScoped(typeof(INurseService), typeof(NurseService));


            builder.Services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));

            builder.Services.AddScoped(typeof(IReceptionistService), typeof(ReceptionistService));
            builder.Services.AddScoped(typeof(IReceptionistRepo), typeof(ReceptionistRepo));


            builder.Services.AddScoped(typeof(IPatientRepo), typeof(PatientRepo));
            builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));

            builder.Services.AddScoped(typeof(IAppointmentService), typeof(AppointmentService));

            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            builder.Services.AddScoped(typeof(ISpecialistDoctorInDepartmentService), typeof(SpecialistDoctorInDepartmentService));
            builder.Services.AddScoped(typeof(ISpecialistDoctorInDepartmentRepo), typeof(SpecialistDoctorInDepartmentRepo));

            builder.Services.AddScoped(typeof(IAddressRepo), typeof(AddressRepo));

            builder.Services.AddScoped(typeof(IGenrateService), typeof(GenrateService));
            builder.Services.AddScoped(typeof(ICachedService<>), typeof(CachedService<>));


            builder.Services.AddScoped(typeof(IBookingService), typeof(BookingService));
            builder.Services.AddScoped(typeof(IPaymentService), typeof(PaymentService));



            builder.Services.AddScoped(typeof(IBillRepo), typeof(BillRepo));


            builder.Services.AddScoped(typeof(IAuthenticationService), typeof(AuthenticationService));
            builder.Services.AddScoped(typeof(IAuthorizationService), typeof(AuthorizationService));








            builder.Services.AddAutoMapper(typeof(AtoMapper));


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(DoctorQueryHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(DoctorCommandHandler).Assembly);

                cfg.RegisterServicesFromAssemblies(typeof(NurseQueryHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(NurseCommandHandler).Assembly);

                cfg.RegisterServicesFromAssemblies(typeof(SpecialistDoctorInDepartmentCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(SpecialistDoctorInDepartmentCommandHandler).Assembly);

                cfg.RegisterServicesFromAssemblies(typeof(DepartmentQueryHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(DepartmentCommandHandler).Assembly);

                cfg.RegisterServicesFromAssemblies(typeof(PatientQueryHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(PatientQueryHandler).Assembly);

                cfg.RegisterServicesFromAssemblies(typeof(AppointmentCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(AppointmentQueryHandler).Assembly);

                cfg.RegisterServicesFromAssemblies(typeof(ReceptionistQueryHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(ReceptionistCommandHandler).Assembly);

                cfg.RegisterServicesFromAssemblies(typeof(BillsCommanHandler).Assembly);


                cfg.RegisterServicesFromAssemblies(typeof(RoleCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(RoleQueryHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(AuthenticationCommandHandler).Assembly);

                //cfg.RegisterServicesFromAssemblies(typeof(Au).Assembly);


            });


            builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
            {
                var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });



            builder.Services.AddPaymobCashIn(config =>
            {
                config.ApiKey = builder.Configuration["Paymob:ApiKey"];
                config.Hmac = builder.Configuration["Paymob:Hmac"];
                //config.IframeBaseUrl = builder.Configuration["Paymob:IframeBaseUrl"];
            });







            var app = builder.Build();



            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                //await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database.");
            }



            // calling the seeding method


            try
            {
                //await Seeding.SeedDataAsync(context, logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
            }





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
