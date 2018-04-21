﻿using System;

namespace AnimalRescue.Core.Exceptions
{
    public class EventHandlersNotRegisteredException : Exception
    {
        private const string Msg = "Handlers not registered. The aggregate may have an overloaded constructor not referencing the event registration constructor.";

        public EventHandlersNotRegisteredException() : base(Msg)
        {
        }
    }
}
