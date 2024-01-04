namespace AdoptMe.Service.Exceptions.Pets
{
    public class PetAlreadyExistsException : AlreadyExistsException
    {
        public PetAlreadyExistsException() : base("The mentioned pet already exists.") { }
        public PetAlreadyExistsException(string message) : base(message) { }
    }
}
