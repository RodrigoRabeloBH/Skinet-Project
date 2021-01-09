using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandRepository _rep;

        public ProductBrandController(IProductBrandRepository rep)
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
        public async Task<IActionResult> Create(ProductBrand productBrand)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _rep.Create(productBrand);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductBrand productBrand)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _rep.Update(productBrand);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productBrand = await _rep.GetById(id);

            await _rep.Delete(productBrand);
            
            return Ok();
        }
    }
}