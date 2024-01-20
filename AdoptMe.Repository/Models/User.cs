namespace AdoptMe.Repository.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public int? ShelterId { get; set; }
        public Shelter? Shelter { get; set; }
    }
}
