using System.Runtime.Serialization;

namespace AdoptMe.Service.Exceptions
{
    [Serializable]
    internal class ShelterNotFoundException : Exception
    {
        public ShelterNotFoundException()
        {
        }

        public ShelterNotFoundException(string? message) : base(message)
        {
        }

        public ShelterNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ShelterNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}