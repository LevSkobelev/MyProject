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
            List<MenuItem> menuItems = Context.MenuItems.ToList();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(MenuItem menuItem)
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(MenuItem menuItem)
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
