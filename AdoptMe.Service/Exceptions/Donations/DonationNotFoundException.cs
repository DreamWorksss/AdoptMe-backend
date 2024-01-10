namespace AdoptMe.Service.Exceptions.Donations
{
    public class DonationNotFoundException : NotFoundException
    {
        public DonationNotFoundException() : base("The requested donation was not found.") { }
        public DonationNotFoundException(string message) : base(message) { }
    }
}