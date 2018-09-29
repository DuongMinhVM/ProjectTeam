using System;

namespace EntityLayer
{
    public class OrderItemEntity : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalMoney { get; set; }
    }
}