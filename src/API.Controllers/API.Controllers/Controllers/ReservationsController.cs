using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Controllers
{
    public class Reservations
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public string status { get; set; }
        [ApiController]
        [Route("controller")]
        public class ReservationsController : ControllerBase
        {
            public static List<Reservations> reservations = new()
            {

            };



            [HttpGet]
            public List<Reservations> GetAll()
            {
                return reservations;
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int Id)
            {
                for (int i = 0; i < reservations.Count; i++)
                {
                    if (reservations[i].Id == Id)
                    {
                        return Ok(reservations[i]);
                    }
                }
                return BadRequest("peredelivay");
            }
            [HttpPost]
            public IActionResult Add(Reservations data)
            {
                for (int i = 0; i < reservations.Count; i++)
                {
                    if (reservations[i].Id == data.Id)
                    {
                        return BadRequest("Уже есть");
                    }
                }
                reservations.Add(data);
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Reservations data)
            {
                for (int i = 0; i < reservations.Count; i++)
                {
                    if (reservations[i].Id == data.Id)
                    {
                        reservations[i] = data;
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
            [HttpDelete]
            public IActionResult Delete(int Id)
            {
                for (int i = 0; i <= reservations.Count; i++)
                {
                    if (reservations[i].Id == Id)
                    {
                        reservations.RemoveAt(i);
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
        }
    }
}
