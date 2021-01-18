using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Skinet.Api.Dto;
using Skinet.Model.OrderAggregate;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingAddressController : ControllerBase
    {
        private readonly IShippingAddressRepository _rep;
        private readonly IMapper _map;

        public ShippingAddressController(IShippingAddressRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        [HttpGet("{zipcode}")]
        public async Task<IActionResult> GetShippingAddress(string zipcode)
        {
            object shippingAddress = null;

            using (var http = new HttpClient())
            {
                var response = await http.GetAsync("https://viacep.com.br/ws/" + zipcode + "/json/");

                shippingAddress = response.Content.ReadAsStreamAsync().Result;
            }
            return Ok(shippingAddress);
        }

        [HttpPost]
        public async Task<IActionResult> SaveShippingAddress(AddressDto addressDto)
        {
            var shippingAddress = _map.Map<ShippingAddress>(addressDto);

            await _rep.Create(shippingAddress);

            return Ok();
        }
    }
}