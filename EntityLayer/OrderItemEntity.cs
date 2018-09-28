using System;

namespace EntityLayer
{
    public class OrderItemEntity : BaseEntity
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalMoney { get; set; }
    }
}