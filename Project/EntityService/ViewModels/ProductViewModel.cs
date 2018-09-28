namespace EntityService.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? Status { get; set; }
        public int Quantity { get; set; }
    }
}