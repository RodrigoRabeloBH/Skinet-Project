using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Skinet.Api.Dto;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository _rep;
        private readonly IMapper _map;

        public BasketsController(IBasketRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket = await _rep.GetBasket(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(CustomerBasketDto basketDto)
        {
            var basket = _map.Map<CustomerBasket>(basketDto);

            var updatedBasket = await _rep.Update(basket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _rep.DeleteBasket(id);

        }
    }
}