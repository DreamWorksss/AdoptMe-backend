namespace AdoptMe.Service.Exceptions.Shelters
{
    public class ShelterAlreadyExistsException : AlreadyExistsException
    {
        public ShelterAlreadyExistsException() : base("The mentioned shelter already exists.") { }
        public ShelterAlreadyExistsException(string message) : base(message) { }
    }
}
