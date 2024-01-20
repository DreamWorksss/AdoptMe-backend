namespace AdoptMe.Service.Exceptions.Users
{
    public class UserAlreadyExistsException : NotFoundException
    {
        public UserAlreadyExistsException() : base("The requested user already exists.") { }
        public UserAlreadyExistsException(string message) : base(message) { }
    }
}
