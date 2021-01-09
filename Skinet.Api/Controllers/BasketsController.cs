using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository _rep;

        public BasketsController(IBasketRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketById(string id)
        {
            var basket = await _rep.GetBasket(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(CustomerBasket basket)
        {
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