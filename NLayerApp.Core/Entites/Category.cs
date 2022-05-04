namespace NLayerApp.Core.Entites
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products=new List<Product>();
        }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
