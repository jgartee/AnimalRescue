using System;

namespace AnimalRescue.Core.Exceptions
{
    public class CommandHandlerNotRegisteredException : Exception
    {
        private const string MESSAGE = "Handler not registered for command, {0}";

        public CommandHandlerNotRegisteredException(ICommand command)
            : base(string.Format(MESSAGE, command.GetType()))
        {
            Command = command;
        }

        public ICommand Command { get; }
    }
}
