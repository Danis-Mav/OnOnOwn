using Microsoft.AspNetCore.Mvc;
using OnOnOwn;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        [HttpGet]
        public IEnumerable<menu> GetAllMenu()
        {
            return DataAccess.GetAllMenu();
        }
        [HttpGet]
        public IEnumerable<OrderMenu> GetAllOrderMenu()
        {
            return DataAccess.GetAllOrderMenu();
        }


        [HttpPost("{NameDish}/{price}/{description}/{IDcountry}/{IDtype}/{IsDelete}/{IsST}")]
        public IActionResult AddMenu(string NameDish, int price, string description,int IDcountry,int IDtype,bool IsDelete,bool IsST)
        {
            DataAccess.AddMenu(NameDish, price, description, IDcountry, IDtype,IsDelete,IsST);
            return Content("dish created");
        }
        [HttpPost("{Idmenu}/{price}/{idorder}/{IsOrder}")]
        public IActionResult AddOrderMenu(int Idmenu, int idorder, int price, bool IsOrder)
        {
            DataAccess.AddOrderMenu(Idmenu, price, idorder, IsOrder);
            return Content("dish created");
        }
    }
}
