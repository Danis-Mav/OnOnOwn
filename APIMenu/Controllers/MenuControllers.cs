using Microsoft.AspNetCore.Mvc;
using OnOnOwn;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuControllers : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<List<menu>> GetAllMenu()
        {
            return (IEnumerable<List<menu>>)DataAccess.Getmenu();
        }



        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult AddMenu(string NameDish, int price, string description, int IDcountry, int IDtype, bool IsDelete, bool IsST)
        {
            DataAccess.AddMenu(NameDish, price, description, IDcountry, IDtype, IsDelete, IsST);
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
