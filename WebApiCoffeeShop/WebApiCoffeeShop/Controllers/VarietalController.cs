using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoffeeShop.Entities;

namespace WebApiCoffeeShop.Controllers
{
    [ApiController]
    [Route("api/varietal")]
    public class VarietalController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public VarietalController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Varietal>>> Get()
        {
            return await context.Varietales.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Varietal>> Get(int id)
        {
            return await context.Varietales.Include(varietal => varietal.Specie).FirstOrDefaultAsync(varietal => varietal.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Varietal varietal)
        {
            var existsSpecie = await context.Species.AnyAsync(specie => specie.Id == varietal.SpecieId);
            if (!existsSpecie)
            {
                return BadRequest($"Specie with id {varietal.SpecieId} does not exist");
            }
            context.Add(varietal);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
