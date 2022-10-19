namespace WebApiCoffeeShop.Entities
{
    public class Specie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Varietal> Varietales { get; set; }
    }
}
