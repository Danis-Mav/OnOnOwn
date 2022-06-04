using Microsoft.AspNetCore.Mvc;
using OnOnOwn;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMenuControllers : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("Контроллер2")]
        public IEnumerable<OrderMenu> GetAllOrderMenu()
        {
            return DataAccess.GetOrderMenu();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult AddOrderMenu(int Idmenu, int idorder, int price, bool IsOrder)
        {
            DataAccess.AddOrderMenu(Idmenu, price, idorder, IsOrder);
            return Content("dish created");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
