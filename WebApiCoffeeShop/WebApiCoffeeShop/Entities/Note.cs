using System.ComponentModel.DataAnnotations;

namespace WebApiCoffeeShop.Entities
{
    public class Note
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        public string Description { get; set; }
    }
}
