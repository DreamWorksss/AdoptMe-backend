using AdoptMe.Common.CommonConstants;

namespace AdoptMe.Web.Models.Users
{
    public class UserRegisterModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; } = UserRoles.Admin;
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ShelterId { get; set; } = 0;
    }
}
