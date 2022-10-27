using System.ComponentModel.DataAnnotations;

namespace WebApiCoffeeShop.Entities
{
    public class Specie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        public string Name { get; set; }
        public List<Varietal> Varietales { get; set; }
    }
}
