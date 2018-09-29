using System;

namespace EntityLayer
{
    public class MerchantEntity : BaseEntity
    {
        public string Name { get; set; }
        public Guid CountriesId { get; set; }
        public Guid UserId { get; set; }
    }
}