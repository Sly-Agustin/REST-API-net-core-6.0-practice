using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoffeeShop.Entities;

namespace WebApiCoffeeShop.Controllers
{
    [ApiController]
    [Route("api/coffee")]   // Could be "api/[controller]"
    public class CoffeeController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CoffeeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Get all coffees
        [HttpGet]
        public async Task<ActionResult<List<Coffee>>> Get()
        {
            return await context.Coffes.ToListAsync();
            // Refactor this later, id generation, dynamic...
            /*return new List<Coffee>() { 
                new Coffee() { Id = 1, Name = "Santos", Source = "Brasil", Height = 1200 },
                new Coffee() { Id = 2, Name = "Guanes Genuino", Source = "Colombia", Height = 1600 },
            };*/
        }

        // Get a coffee by id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Coffee>> GetSpecificCoffee(int id)
        {
            var coffee = await context.Coffes.FirstOrDefaultAsync(coffee => coffee.Id == id);
            if (coffee == null)
            {
                return NotFound($"Coffee of id {id} does not exist in the database");
            }
            return coffee;
        }
        
        // Get a coffee by name
        [HttpGet("{name}")]
        public async Task<ActionResult<Coffee>> GetSpecificCoffee(string name)
        {
            var coffee = await context.Coffes.FirstOrDefaultAsync(coffee => coffee.Name == name);
            if (coffee == null)
            {
                return NotFound($"Coffee of name {name} does not exist in the database");
            }
            return coffee;
        }

        // Get the first coffee entry in the database
        [HttpGet("first")]
        public async Task<ActionResult<Coffee>> FirstCoffe()
        {
            return await context.Coffes.FirstOrDefaultAsync();
        }

        // This allows to receive coffees in a post and save them in the database
        [HttpPost]
        public async Task<ActionResult> Post(Coffee coffee)
        {
            context.Add(coffee);
            await context.SaveChangesAsync();
            return Ok();
        }

        // Update a coffee information
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Coffee coffee, int id)
        {
            var exists = await context.Coffes.AnyAsync(coffee => coffee.Id == id);
            if (!exists)
            {
                return NotFound("Coffee id does no exists in database");
            }
            if (coffee.Id != id)
            {
                return BadRequest("Coffee id does not match URL id");
            }
            context.Update(coffee);
            await context.SaveChangesAsync();
            return Ok();
        }

        // Delete a coffee from the database
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(Coffee coffee, int id)
        {
            var exists = await context.Coffes.AnyAsync(coffee => coffee.Id == id);
            if (!exists)
            {
                return NotFound("Coffee id does no exists in database");
            }
            if (coffee.Id != id)
            {
                return BadRequest("Coffee id does not match URL id");
            }
            // This does not create a new Coffee, it instanciates an object of Coffee type
            context.Remove(new Coffee() { Id = id});
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
