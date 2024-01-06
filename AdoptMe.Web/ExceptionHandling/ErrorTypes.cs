namespace AdoptMe.Web.ExceptionHandling
{
    public static class ErrorTypes
    {
        public const string NotFound = "not-found-error";
        public const string AlreadyExists = "already-exists-error";
        public const string Unauthorized = "unauthorized-error";
        public const string Forbidden = "forbidden-error";
        public const string InternalServerError = "internal-server-error";
    }

    public static class WarningTypes
    {
        public const string ApplicationWarning = "application-warning";
    }
}
