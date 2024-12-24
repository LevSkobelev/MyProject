using API.Controllers.Mod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationContext : ControllerBase
    {
        public ReservationContext Context { get; }
        public ReservationContext(ReservationContext context)
        {
            Context = context;
        }
        public IActionResult GetAll()
        {
            List<MenuItem> menuItems = Context.MenuItem.ToList();
            return Ok();
        }
    }
}
