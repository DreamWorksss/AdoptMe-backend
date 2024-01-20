using System.ComponentModel.DataAnnotations;

namespace AdoptMe.Web.Models.Users
{
    public class UserAuthModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
