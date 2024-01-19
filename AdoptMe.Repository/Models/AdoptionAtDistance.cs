namespace AdoptMe.Repository.Models
{
    public class AdoptionAtDistance
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string UserEmail { get; set; }
        public decimal Money { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextDate { get; set; }

        public AdoptionAtDistance() { }

        public AdoptionAtDistance(int id, int petid, string email, decimal money, DateTime startDate, DateTime nextDate)
        {
            Id = id;
            PetId = petid;
            UserEmail = email;
            Money = money;
            StartDate = startDate;
            NextDate = nextDate;
        }

        public AdoptionAtDistance(int petid, string email, decimal money, DateTime startDate, DateTime nextDate)
        {
            PetId = petid;
            UserEmail = email;
            Money = money;
            StartDate = startDate;
            NextDate = nextDate;
        }
    }
}
