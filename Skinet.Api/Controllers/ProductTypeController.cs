using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _rep;

        public ProductTypeController(IProductTypeRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rep.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rep.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductType productType)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _rep.Create(productType);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductType productType)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _rep.Update(productType);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productType = await _rep.GetById(id);

            await _rep.Delete(productType);

            return Ok();
        }
    }
}