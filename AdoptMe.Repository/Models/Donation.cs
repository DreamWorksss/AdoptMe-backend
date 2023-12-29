namespace AdoptMe.Repository.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string UserEmail { get; set; }
        public float Money { get; set; }

        public Donation(int id, int petid, string email, float money)
        {
            Id = id;
            PetId = petid;
            UserEmail = email;
            Money = money;
        }

        public Donation(int petid, string email, float money)
        {
            PetId = petid;
            UserEmail = email;
            Money = money;
        }
    }
}
