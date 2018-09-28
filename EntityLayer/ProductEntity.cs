namespace EntityLayer
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? Status { get; set; }
        public int Quantity { get; set; }
    }
}