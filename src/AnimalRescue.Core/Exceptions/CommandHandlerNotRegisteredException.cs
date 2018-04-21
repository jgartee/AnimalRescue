using System;

namespace AnimalRescue.Core.Exceptions
{
    public class CommandHandlerNotRegisteredException : Exception
    {
        private const string Msg = "Handler not registered for command, {0}";

        public CommandHandlerNotRegisteredException(ICommand command)
            : base(string.Format(Msg, command.GetType()))
        {
            Command = command;
        }

        public ICommand Command { get; }
    }
}
