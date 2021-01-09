using Microsoft.AspNetCore.Mvc;
using Skinet.Api.Errors;
using Skinet.Data;

namespace Skinet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly SkinetContext _context;
        public BuggyController(SkinetContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFountRequest()
        {
            var thing = _context.Product.Find(42);

            if (thing == null) return NotFound(new ApiResponse(404));

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Product.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}