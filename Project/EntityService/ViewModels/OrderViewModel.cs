using System;

namespace EntityService.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public Guid UserID { get; set; }
        public bool? Status { get; set; }
    }
}