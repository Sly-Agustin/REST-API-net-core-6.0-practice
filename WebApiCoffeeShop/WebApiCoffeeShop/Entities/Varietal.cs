using System.ComponentModel.DataAnnotations;

namespace WebApiCoffeeShop.Entities
{
    public class Varietal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        public string Name { get; set; }
        public int SpecieId { get; set; }
        public Specie Specie { get; set; }
    }
}
