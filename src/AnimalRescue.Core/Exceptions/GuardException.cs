using System;

namespace AnimalRescue.Core.Exceptions
{
    public class GuardException : Exception
    {
        public GuardException(string message) : base(message)
        {
        }
    }
}
