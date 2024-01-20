namespace AdoptMe.Common.CommonConstants
{
    public class DefaultConstants
    {
        public static int DefaultPage = 0;
        public static int DefaultPageSize = 10;
    }

    public class ServerConstants
    {
        public const string SecretKey = "SecretKey";
        public const string Issuer = "Issuer";
        public const string Audience = "Audience";
        public const string ExpirationTime = "Expiration";
        public const string Token = "TokenSettings";
    }

    public class ServerErrorMessages
    {
        public const string InvalidToken = "Your session has expired! Please login again";
    }
}
