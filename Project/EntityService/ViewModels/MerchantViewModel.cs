using System;

namespace EntityService.ViewModels
{
    public class MerchantViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public Guid CountriesID { get; set; }
        public Guid UserID { get; set; }
    }
}