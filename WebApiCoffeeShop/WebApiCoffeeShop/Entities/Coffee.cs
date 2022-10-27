using System.ComponentModel.DataAnnotations;
using WebApiCoffeeShop.Validations;

namespace WebApiCoffeeShop.Entities
{
    public class Coffee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        [FirstLetterCapital]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        [FirstLetterCapital]
        public string Source { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        [Range(0,7000, ErrorMessage = "{0} must be between {1} and {2}")]
        public int Height { get; set; }
        //public List<Note> Notes { get; set; }
    }
}
