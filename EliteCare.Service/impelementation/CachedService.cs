using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Service.Abstract;
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

        public CachedService(IConnectionMultiplexer rdx, IUnitOfWork unitOfWork)
        {
            _database = rdx.GetDatabase();
            _unitOfWork = unitOfWork;
        }

        private async Task<Dictionary<string, object>> GetUpdatedAttribute(T data)
        {
            T originalData = await _unitOfWork.Repo<T>().GetByIdAsync(data.ID);
            var updatedAttributes = new Dictionary<string, object>();

            if (originalData == null)
                return updatedAttributes;

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var originalValue = property.GetValue(originalData);
                var currentValue = property.GetValue(data);

                if (!Equals(originalValue, currentValue)) // Check if values are different
                {
                    updatedAttributes[property.Name] = currentValue;
                }
            }

            return updatedAttributes;
        }

        public async Task AddCachedData(string key, T data)
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
