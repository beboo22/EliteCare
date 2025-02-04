using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Service.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class CachedService<T> : ICachedService<T> where T : BaseEntity, new()
    {
        private readonly IDatabase _database;

        public IUnitOfWork _unitOfWork;
        private readonly IGenrateService _genrateService;

        public CachedService(IConnectionMultiplexer rdx, IUnitOfWork unitOfWork,IGenrateService genrateService)
        {
            _database = rdx.GetDatabase();
            _unitOfWork = unitOfWork;
            _genrateService = genrateService;
        }

        private async Task<Dictionary<string, object>> GetUpdatedAttribute(T data)
        {
            var service = await _genrateService.GenerateService<T>(data.ID);
            T originalData = await _unitOfWork.Repo<T>().GetByIDSpecification(service);
            var updatedAttributes = new Dictionary<string, object>();

            if (originalData == null)
                return updatedAttributes;

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == "Department" || property.Name == "AddressId")
                    continue;
                var originalValue = property.GetValue(originalData);
                var currentValue = property.GetValue(data);

                if (property.PropertyType == typeof(Address))
                {
                    var originalAddress = originalValue as Address;
                    var currentAddress = currentValue as Address;

                    if (!Equals(originalAddress, currentAddress))
                    {
                        var updatedAddress = new Dictionary<string, object>();

                        if (originalAddress == null || currentAddress == null)
                        {
                            updatedAttributes[property.Name] = currentAddress;
                            continue;
                        }

                        if (!Equals(originalAddress.City, currentAddress.City))
                            updatedAddress["City"] = currentAddress.City;
                        if (!Equals(originalAddress.country, currentAddress.country))
                            updatedAddress["Country"] = currentAddress.country;
                        if (!Equals(originalAddress.State, currentAddress.State))
                            updatedAddress["State"] = currentAddress.State;
                        if (!Equals(originalAddress.Street, currentAddress.Street))
                            updatedAddress["Street"] = currentAddress.Street;
                        if (!Equals(originalAddress.Zip, currentAddress.Zip))
                            updatedAddress["ZipCode"] = currentAddress.Zip;

                        if (updatedAddress.Any())
                            updatedAttributes[property.Name] = updatedAddress;
                    }
                }
                else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?) ||
                         property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    if (!Equals(originalValue, currentValue))
                        updatedAttributes[property.Name] = currentValue;
                }
                else
                {
                    if (!Equals(originalValue, currentValue))
                        updatedAttributes[property.Name] = currentValue;
                }
            }

            return updatedAttributes;
        }


        public async Task<bool> AddCachedData(string key, T data)
        {
            try
            {

                if (data.ID > 0)
                {
                    var updatedAttributes = await GetUpdatedAttribute(data);

                    if (updatedAttributes.Any())
                    {
                        var response = JsonSerializer.Serialize(updatedAttributes, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        await setCacheAsync(key, response);
                    }
                }
                else
                {
                    var response = JsonSerializer.Serialize(data, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    await setCacheAsync(key, response);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        private async Task setCacheAsync(string key, string value)
        {
            await _database.StringSetAsync(key, value, TimeSpan.FromDays(30));
        }

        public async Task RemoveCachedData(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }
}
