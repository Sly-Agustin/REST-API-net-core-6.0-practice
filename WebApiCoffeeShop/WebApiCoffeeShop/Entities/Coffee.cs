using System.ComponentModel.DataAnnotations;

namespace WebApiCoffeeShop.Entities
{
    public class Coffee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        public string Source { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        public int Height { get; set; }
        //public List<Note> Notes { get; set; }
    }
}
