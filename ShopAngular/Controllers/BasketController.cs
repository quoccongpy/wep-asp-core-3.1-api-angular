using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAngular.Model.Entities;
using ShopAngular.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAngular.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasket(id);
            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var data = await _basketRepository.UpdateBasket(basket);
            return Ok(data);
        }
        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await  _basketRepository.DeleteBasket(id);
           
        }
    }
}
