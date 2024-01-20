namespace AdoptMe.Repository.Models
{
    public class AdoptionAtDistance
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string UserName {  get; set; }
        public string PhoneNumber {  get; set; }
        public string UserEmail { get; set; }
        public decimal Sum { get; set; }
        public string Frequency {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentMethod { get; set; }

        public AdoptionAtDistance() { }

        public AdoptionAtDistance(int id, int petid, string userName, string phoneNumber, string userEmail, decimal sum, string frequency, DateTime startDate, DateTime endDate, string paymentMethod)
        {
            Id = id;
            PetId = petid; 
            UserName = userName;
            PhoneNumber = phoneNumber;
            UserEmail = userEmail;
            Sum = sum;
            Frequency = frequency;
            StartDate = startDate;
            EndDate = endDate;
            PaymentMethod = paymentMethod;
        }

        public AdoptionAtDistance(int petid, string userName, string phoneNumber, string userEmail, decimal sum, string frequency, DateTime startDate, DateTime endDate, string paymentMethod)
        {
            PetId = petid;
            UserName = userName;
            PhoneNumber = phoneNumber;
            UserEmail = userEmail;
            Sum = sum;
            Frequency = frequency;
            StartDate = startDate;
            EndDate = endDate;
            PaymentMethod = paymentMethod;
        }
    }
}
