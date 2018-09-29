using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EntityLayer
{
    public class UserEntity : IdentityUser
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