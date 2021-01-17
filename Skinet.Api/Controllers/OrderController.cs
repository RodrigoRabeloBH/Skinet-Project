using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Api.Dto;
using Skinet.Api.Errors;
using Skinet.Api.Extensions;
using Skinet.Model.OrderAggregate;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _rep;
        private readonly IMapper _map;
        public OrderController(IOrderRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var shippingAddress = _map.Map<AddressDto, ShippingAddress>(orderDto.ShippingAddres);

            var order = await _rep.CreateOrder(email, orderDto.DeliveryMethodId, orderDto.BasketId, shippingAddress);

            if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order."));

            return Ok(order);
        }
    }
}