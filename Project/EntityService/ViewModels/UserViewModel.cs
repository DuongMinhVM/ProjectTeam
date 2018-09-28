using System;

namespace EntityService.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid CountryID { get; set; }
    }
}