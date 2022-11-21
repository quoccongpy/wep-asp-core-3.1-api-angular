using ShopAngular.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAngular.Model.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasket(string basketId);
        Task<CustomerBasket> UpdateBasket(CustomerBasket basket);
        Task<bool> DeleteBasket(string basketId);
    }
}
