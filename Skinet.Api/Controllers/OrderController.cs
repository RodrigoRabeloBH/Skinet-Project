using System.Collections.Generic;
using System.Security.Claims;
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
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
        {
            string email = HttpContext.User.RetrieveEmailFromPrincipal();

            string customerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var shippingAddress = _map.Map<AddressDto, ShippingAddress>(orderDto.ShippingAddress);

            var order = await _rep.CreateOrder(customerId, email, orderDto.DeliveryMethodId, orderDto.BasketId, shippingAddress);

            if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order."));

            return Ok(_map.Map<OrderToReturnDto>(order));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetById(int id)
        {
            string email = HttpContext.User.RetrieveEmailFromPrincipal();

            Order order = await _rep.GetOrderById(id, email);

            return Ok(_map.Map<OrderToReturnDto>(order));
        }

        [HttpGet("deliverymethods")]
        public async Task<ActionResult<List<DeliveryMethod>>> GetDeliveryMethods()
        {

            var deliverymethods = await _rep.GetDeliveryMethods();

            return Ok(deliverymethods);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderToReturnDto>>> GetOrdersForUser()
        {
            string email = HttpContext.User.RetrieveEmailFromPrincipal();

            string customerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var orders = await _rep.GetOrdersForUser(email, customerId);

            return Ok(_map.Map<List<OrderToReturnDto>>(orders));
        }
    }
}