using Microsoft.AspNetCore.Mvc;
using WebApiCoffeeShop.Entities;

namespace WebApiCoffeeShop.Controllers
{
    [ApiController]
    [Route("api/coffee")]
    public class CoffeeController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Coffee>> Get()
        {
            // Refactor this later, id generation, dynamic...
            return new List<Coffee>() { 
                new Coffee() { Id = 1, Name = "Santos", Source = "Brasil", Height = 1200 },
                new Coffee() { Id = 2, Name = "Guanes Genuino", Source = "Colombia", Height = 1600 },
            };
        }
    }
}
