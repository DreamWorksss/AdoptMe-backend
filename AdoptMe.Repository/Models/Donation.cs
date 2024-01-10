namespace AdoptMe.Repository.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string UserEmail { get; set; }
        public decimal Money { get; set; }

        public Donation() { }

        public Donation(int id, int petid, string email, decimal money)
        {
            Id = id;
            PetId = petid;
            UserEmail = email;
            Money = money;
        }

        public Donation(int petid, string email, decimal money)
        {
            PetId = petid;
            UserEmail = email;
            Money = money;
        }
    }
}
