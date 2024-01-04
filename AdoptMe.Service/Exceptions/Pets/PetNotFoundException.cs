namespace AdoptMe.Service.Exceptions.Pets
{
    public class PetNotFoundException : NotFoundException
    {
        public PetNotFoundException() : base("The requested pet was not found.") { }
        public PetNotFoundException(string message) : base(message) { }
    }
}
