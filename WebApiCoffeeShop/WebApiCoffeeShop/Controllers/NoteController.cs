using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoffeeShop.Entities;

namespace WebApiCoffeeShop.Controllers
{
    [ApiController]
    [Route("api/note")]
    public class NoteController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public NoteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> Get()
        {
            return await context.Notes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Note>> Get(int id)
        {
            return await context.Notes.FirstOrDefaultAsync(note => note.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> Post(Note note)
        {
            context.Add(note);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
