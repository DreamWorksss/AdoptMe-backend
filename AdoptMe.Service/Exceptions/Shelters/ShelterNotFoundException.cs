namespace AdoptMe.Service.Exceptions.Shelters
{
    public class ShelterNotFoundException : NotFoundException
    {
        public ShelterNotFoundException() : base("The requested shelter was not found.") { }
        public ShelterNotFoundException(string message) : base(message) { }
    }
}