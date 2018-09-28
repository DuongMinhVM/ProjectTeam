using System;

namespace EntityLayer
{
    public abstract class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FulllName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid CountryId { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}