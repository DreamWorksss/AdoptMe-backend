namespace AdoptMe.Service.Exceptions.AdoptionRequests
{
    public class AdoptionRequestNotFoundException : NotFoundException
    {
        public AdoptionRequestNotFoundException() : base("The requested adoptionRequest was not found.") { }
        public AdoptionRequestNotFoundException(string message) : base(message) { }
    }
}