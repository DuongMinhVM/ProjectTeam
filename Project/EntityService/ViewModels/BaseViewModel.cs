using System;

namespace EntityService.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}