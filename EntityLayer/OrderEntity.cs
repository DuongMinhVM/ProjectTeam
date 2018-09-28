using System;

namespace EntityLayer
{
    public class OrderEntity : BaseEntity
    {
        public Guid UserID { get; set; }
        public bool? Status { get; set; }
    }
}