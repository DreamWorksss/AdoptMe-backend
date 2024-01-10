namespace AdoptMe.Web.Models.Donations
{
    public class DonationAdditionModel
    {
        public int PetId { get; set; }
        public string UserEmail { get; set; }
        public decimal Money { get; set; }
    }
}
