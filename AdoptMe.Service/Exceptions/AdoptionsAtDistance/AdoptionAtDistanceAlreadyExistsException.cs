namespace AdoptMe.Service.Exceptions.AdoptionsAtDistance
{
    public class AdoptionAtDistanceAlreadyExistsException : AlreadyExistsException
    {
        public AdoptionAtDistanceAlreadyExistsException() : base("The mentioned adoption at distance already exists.") { }
        public AdoptionAtDistanceAlreadyExistsException(string message) : base(message) { }
    }
}
