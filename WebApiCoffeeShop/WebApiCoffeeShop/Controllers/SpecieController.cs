using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoffeeShop.Entities;

namespace WebApiCoffeeShop.Controllers
{
    [ApiController]
    [Route("api/specie")]
    public class SpecieController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public SpecieController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Specie>>> Get()
        {
            return await context.Species.Include(specie => specie.Varietales).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Specie specie)
        {
            context.Add(specie);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
