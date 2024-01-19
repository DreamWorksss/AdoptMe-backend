namespace AdoptMe.Service.Exceptions.AdoptionsAtDistance
{
    public class AdoptionAtDistanceNotFoundException : NotFoundException
    {
        public AdoptionAtDistanceNotFoundException() : base("The requested adoption at distance was not found.") { }
        public AdoptionAtDistanceNotFoundException(string message) : base(message) { }
    }
}