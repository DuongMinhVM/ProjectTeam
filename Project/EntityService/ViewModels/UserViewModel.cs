using System;

namespace EntityService.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FulllName { get; set; }
        public string Avatar { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid CountryId { get; set; }
        public string Password { get; set; }
    }
}