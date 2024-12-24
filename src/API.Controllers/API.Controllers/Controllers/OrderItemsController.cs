using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Controllers
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        [ApiController]
        [Route("controller")]
        public class OrderItemsController : ControllerBase
        {
            public static List<OrderItems> orderItems = new()
            {

            };



            [HttpGet]
            public List<OrderItems> GetAll()
            {
                return orderItems;
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int Id)
            {
                for (int i = 0; i < orderItems.Count; i++)
                {
                    if (orderItems [i].Id == Id)
                    {
                        return Ok(orderItems[i]);
                    }
                }
                return BadRequest("peredelivay");
            }
            [HttpPost]
            public IActionResult Add(OrderItems data)
            {
                for (int i = 0; i < orderItems.Count; i++)
                {
                    if (orderItems[i].Id == data.Id)
                    {
                        return BadRequest("Уже есть");
                    }
                }
                orderItems.Add(data);
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(OrderItems data)
            {
                for (int i = 0; i < orderItems.Count; i++)
                {
                    if (orderItems[i].Id == data.Id)
                    {
                        orderItems[i] = data;
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
            [HttpDelete]
            public IActionResult Delete(int Id)
            {
                for (int i = 0; i <= orderItems.Count; i++)
                {
                    if (orderItems[i].Id == Id)
                    {
                        orderItems.RemoveAt(i);
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
        }
    }
}
