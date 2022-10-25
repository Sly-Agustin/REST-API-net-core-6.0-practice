namespace WebApiCoffeeShop.Entities
{
    public class Varietal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecieId { get; set; }
        public Specie Specie { get; set; }
    }
}
