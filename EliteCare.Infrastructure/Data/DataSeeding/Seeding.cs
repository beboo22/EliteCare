using EliteCare.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Data.DataSeeding
{
    public static class Seeding
    {
        public async static Task SeedDataAsync(ApplicationDbContext context,ILogger logger)
        {
            if (!context.Set<Department>().Any())
            {
                var connection = "";
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Department.json");
                if (!File.Exists(fileName))
                {
                     logger.LogError("Department.json file not found");
                    return;
                }
                connection = File.ReadAllText(fileName);
                var data = JsonSerializer.Deserialize<List<Department>>(connection);
                if(data is not null)
                {
                    await context.Departments.AddRangeAsync(data);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error while saveing Changes");
                    }
                }
            }
                        
            if (!context.Set<Doctor>().Any())
            {
                var connection = "";
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Doctors.json");
                if (!File.Exists(fileName))
                {
                     logger.LogError("Department.json file not found");
                    return;
                }
                connection = File.ReadAllText(fileName);
                var data = JsonSerializer.Deserialize<List<Doctor>>(connection);
                foreach (var doctor in data)
                {
                    
                    var address = new Address
                    {
                        City = doctor.Address.City,
                        country = doctor.Address.country,
                        Street = doctor.Address.Street,
                        Zip = doctor.Address.Zip,
                        State = doctor.Address.State
                    };
                    await context.Set<Address>().AddAsync(address);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError($"Error while saveing Changes of Address of the Doctor's name is {doctor.Fname}");
                    }
                    doctor.AddressId = address.Id;
                    await context.Set<Doctor>().AddAsync(doctor);
                }
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError("Error while saveing Changes");
                }
            }
            
            if (!context.Set<Room>().Any())
            {
                var connection = "";
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Rooms.json");
                if (!File.Exists(fileName))
                {
                     logger.LogError("Department.json file not found");
                    return;
                }
                connection = File.ReadAllText(fileName);
                var data = JsonSerializer.Deserialize<List<Room>>(connection);
                if(data is not null)
                {
                    await context.Set<Room>().AddRangeAsync(data);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Error while saveing Changes");
                    }
                }
            }
            
            if (!context.Set<Nurse>().Any())
            {
                var connection = "";
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Nurses.json");
                if (!File.Exists(fileName))
                {
                     logger.LogError("Nurses.json file not found");
                    return;
                }
                connection = File.ReadAllText(fileName);
                var data = JsonSerializer.Deserialize<List<Nurse>>(connection);
                foreach (var nurse in data)
                {
                    
                    var address = new Address
                    {
                        City = nurse.Address.City,
                        country = nurse.Address.country,
                        Street = nurse.Address.Street,
                        Zip = nurse.Address.Zip,
                        State = nurse.Address.State
                    };
                    await context.Set<Address>().AddAsync(address);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError($"Error while saveing Changes of Address of the Nurses's name is {nurse.Fname}");
                    }
                    nurse.AddressId = address.Id;
                    await context.Set<Nurse>().AddAsync(nurse);
                }
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError("Error while saveing Changes");
                }
            }
            
            if (!context.Set<Patient>().Any())
            {
                var connection = "";
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Patient.json");
                if (!File.Exists(fileName))
                {
                     logger.LogError("Nurses.json file not found");
                    return;
                }
                connection = File.ReadAllText(fileName);
                var data = JsonSerializer.Deserialize<List<Patient>>(connection);
                foreach (var patient in data)
                {
                    
                    var address = new Address
                    {
                        City = patient.Address.City,
                        country = patient.Address.country,
                        Street = patient.Address.Street,
                        Zip = patient.Address.Zip,
                        State = patient.Address.State
                    };
                    await context.Set<Address>().AddAsync(address);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError($"Error while saveing Changes of Address of the Nurses's name is {patient.Fname}");
                    }
                    patient.AddressId = address.Id;
                    await context.Set<Patient>().AddAsync(patient);
                }
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError("Error while saveing Changes");
                }
            }
        
        
        
        
        
        
        
        
        
        
        }






    }
}
