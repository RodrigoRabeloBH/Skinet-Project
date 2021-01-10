using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Model;
using Skinet.Service.Interfaces;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TierPriceController : ControllerBase
    {
        private readonly ITierPriceRepository _rep;

        public TierPriceController(ITierPriceRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tierprices = await _rep.GetAll();

            return Ok(tierprices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rep.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TierPrice tierPrice)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _rep.Create(tierPrice);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TierPrice tierPrice)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _rep.Update(tierPrice);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tierPrice = await _rep.GetById(id);

            await _rep.Delete(tierPrice);

            return Ok();
        }
    }
}