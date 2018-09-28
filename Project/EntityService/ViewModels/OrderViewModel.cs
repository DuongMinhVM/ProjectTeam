using System;

namespace EntityService.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public Guid UserId { get; set; }
        public bool? Status { get; set; }
    }
}