using System;

namespace EntityService.ViewModels
{
    public abstract class MerchantViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public Guid CountriesId { get; set; }
        public Guid UserId { get; set; }
    }
}