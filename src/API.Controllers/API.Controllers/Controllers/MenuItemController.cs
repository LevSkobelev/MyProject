using API.Controllers.Mod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        public ReservationContext Context { get; }

        public MenuItemController(ReservationContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<MenuItem> menuItems = Context.MenuItem.ToList();
            return Ok();
        }

    }
}
