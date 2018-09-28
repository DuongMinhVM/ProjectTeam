using System;

namespace EntityLayer
{
    public class MerchantEntity : BaseEntity
    {
        public string Name { get; set; }
        public Guid CountriesID { get; set; }
        public Guid UserID { get; set; }
    }
}