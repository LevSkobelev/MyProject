using API.Controllers.Mod;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Customers
    {
        public class CustomersController : ControllerBase
        {
            public static List<Customer> customers = new()
            {
             
            };

            

            [HttpGet]
            public List<Customer> GetAll()
            {
                return customers;
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int Id)
            {
                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].Id == Id)
                    {
                        return Ok(customers[i]);
                    }
                }
                return BadRequest("peredelivay");
            }
            [HttpPost]
            public IActionResult Add(Customer data)
            {
                for (int i = 0; i < customers.Count; i++) 
                {
                    if (customers[i].Id == data.Id)
                    {
                        return BadRequest("Уже есть");
                    }
                }
                customers.Add(data);
                return Ok();
            }
            [HttpPut]
            public IActionResult Update (Customer data)
            {
                for (int i = 0;i < customers.Count; i++)
                {
                    if (customers[i].Id == data.Id)
                    {
                        customers[i] = data;
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
            [HttpDelete]
            public IActionResult Delete(int Id)
            {
                for (int i = 0; i <= customers.Count; i++)
                {
                    if (customers[i].Id == Id)
                    {
                        customers.RemoveAt(i);
                        return Ok();
                    }
                }
                return BadRequest("нет такой записи");
            }
        }
    }
}
