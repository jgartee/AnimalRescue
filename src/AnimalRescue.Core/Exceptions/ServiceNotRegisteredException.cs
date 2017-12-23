using System;

namespace AnimalRescue.Core.Exceptions
{
    public class ServiceNotRegisteredException : Exception
    {
        public ServiceNotRegisteredException(Exception innerException) : base(innerException.Message, innerException)
        {
        }
    }
}
