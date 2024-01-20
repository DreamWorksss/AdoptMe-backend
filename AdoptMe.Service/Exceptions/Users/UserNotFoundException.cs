namespace AdoptMe.Service.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base("The requested user was not found.") { }
        public UserNotFoundException(string message) : base(message) { }
    }
}
