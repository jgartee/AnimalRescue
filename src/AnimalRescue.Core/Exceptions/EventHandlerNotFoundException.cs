using System;

namespace AnimalRescue.Core.Exceptions
{
    public class EventHandlerNotFoundException : Exception
    {
        private const string MESSAGE = "Handler not found.";

        public EventHandlerNotFoundException() : base(MESSAGE)
        {
        }
    }
}
