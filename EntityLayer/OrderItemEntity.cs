using System;

namespace EntityLayer
{
    public abstract class OrderItemEntity : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalMoney { get; set; }
    }
}