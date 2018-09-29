using System;

namespace EntityLayer
{
    public class OrderEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public string CouponCode { get; set; }
    }
}