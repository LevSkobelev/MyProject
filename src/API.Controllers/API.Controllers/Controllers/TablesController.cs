using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers.Controllers
{
    public class Tables
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        [ApiController]
        [Route("controller")]
        public class TablesController : ControllerBase
        {
            public static List<Tables> tables = new()
            {

            };



            [HttpGet]
            public List<Tables> GetAll()
            {
                return tables;
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int Id)
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i].Id == Id)
                    {
                        return Ok(tables[i]);
                    }
                }
                return BadRequest("peredelivay");
            }
            [HttpPost]
            public IActionResult Add(Tables data)
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i].Id == data.Id)
                    {
                        return BadRequest("Уже есть");
                    }
                }
                tables.Add(data);
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Tables data)
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i].Id == data.Id)
                    {
                        tables[i] = data;
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
            [HttpDelete]
            public IActionResult Delete(int Id)
            {
                for (int i = 0; i <= tables.Count; i++)
                {
                    if (tables[i].Id == Id)
                    {
                        tables.RemoveAt(i);
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
        }
    }
}
