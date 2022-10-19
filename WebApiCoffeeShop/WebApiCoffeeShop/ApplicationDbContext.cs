using Microsoft.EntityFrameworkCore;
using WebApiCoffeeShop.Entities;

namespace WebApiCoffeeShop
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coffee> Coffes {get; set; }
        public DbSet<Note> Notes {get; set; }
        public DbSet<Varietal> Varietales { get; set; }
        public DbSet<Specie> Species { get; set; }
    }
}
