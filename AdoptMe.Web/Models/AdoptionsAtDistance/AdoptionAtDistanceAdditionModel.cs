namespace AdoptMe.Web.Models.AdoptionsAtDistance
{
    public class AdoptionAtDistanceAdditionModel
    {
        public int PetId { get; set; }
        public string UserEmail { get; set; }
        public decimal Money { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextDate { get; set; }
    }
}
