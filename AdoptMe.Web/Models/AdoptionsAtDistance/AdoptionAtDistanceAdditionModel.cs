namespace AdoptMe.Web.Models.AdoptionsAtDistance
{
    public class AdoptionAtDistanceAdditionModel
    {
        public int PetId { get; set; }
        public string UserName {  get; set; }
        public string PhoneNumber {  get; set; }
        public string UserEmail { get; set; }
        public decimal Sum { get; set; }
        public string Frequency {  get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentMethod {  get; set; }
    }
}
