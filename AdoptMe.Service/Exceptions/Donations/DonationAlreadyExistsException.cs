namespace AdoptMe.Service.Exceptions.Donations
{
    public class DonationAlreadyExistsException : AlreadyExistsException
    {
        public DonationAlreadyExistsException() : base("The mentioned donation already exists.") { }
        public DonationAlreadyExistsException(string message) : base(message) { }
    }
}
