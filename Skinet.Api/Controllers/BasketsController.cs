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
        private readonly IBasketServices _service;
        private readonly IMapper _map;

        public BasketsController(IBasketRepository rep, IBasketServices service, IMapper map)
        {
            _rep = rep;
            _service = service;
            _map = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket = await _rep.GetBasket(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost("basketTotal")]
        public IActionResult CalculateTotals(CustomerBasketDto basketDto)
        {
            var basket = _map.Map<CustomerBasket>(basketDto);

            decimal total = _service.CalculeteTotals(basket);

            return Ok(total);
        }

        [HttpPost("basketItemTotal")]
        public IActionResult CalculeteItemTotal(BasketItemDto itemDto)
        {
            var basketItem = _map.Map<BasketItem>(itemDto);

            decimal total = _service.CalculeteItemTotal(basketItem);

            return Ok(total);
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