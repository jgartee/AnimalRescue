using System;

namespace AnimalRescue.Core.Exceptions
{
    public class EventHandlerNotFoundException : Exception
    {
        private const string Msg = "Handler not found.";

        public EventHandlerNotFoundException() : base(Msg)
        {
        }
    }
}
