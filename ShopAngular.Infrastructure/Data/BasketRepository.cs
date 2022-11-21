using ShopAngular.Model.Entities;
using ShopAngular.Model.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopAngular.Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<CustomerBasket> GetBasket(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : (JsonSerializer.Deserialize<CustomerBasket>(data));
            //serializer : chuyen doi obj thanh json
        }
      
        public async Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if(!created)
            {
                return null;
            }
            return await GetBasket(basket.Id);
        }
        public async Task<bool> DeleteBasket(string basketId)
        {
            var data = await _database.KeyDeleteAsync(basketId);
            return data;
        }



    }
}
