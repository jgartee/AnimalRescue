using System.Security.Claims;
using System.Threading.Tasks;
using AnimalRescue.Core.Exceptions;
using AnimalRescue.Core.Extensions;

namespace AnimalRescue.Core
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceLocator _serviceLocator;

        public CommandProcessor(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<object> ProcessAsync(ICommand command)
        {
            return await ProcessAsync(command, ClaimsPrincipal.Current);
        }

        public async Task<object> ProcessAsync(ICommand command, ClaimsPrincipal user)
        {
            Guard.IsNotNullCommand(command);

            var commandReturnType = command.GetCommandReturnType();

            var handlerType = commandReturnType != null
                ? typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), commandReturnType)
                : typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            dynamic handler = _serviceLocator.GetInstance(handlerType);

            if (handler == null)
                throw new CommandHandlerNotRegisteredException(command);

            if (commandReturnType != null)
                return await handler.HandleAsync((dynamic)command, user);

            await handler.HandleAsync((dynamic)command, user);
            return null;
        }

        public async Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command)
        {
            return await ProcessAsync(command, ClaimsPrincipal.Current);
        }

        public async Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command, ClaimsPrincipal user)
        {
            Guard.IsNotNullCommand(command);

            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            dynamic handler = _serviceLocator.GetInstance(handlerType);

            if (handler == null)
                throw new CommandHandlerNotRegisteredException(command);

            return await handler.HandleAsync((dynamic)command, user);
        }

        private static class Guard
        {
            public static void IsNotNullCommand(ICommand command)
            {
                if (command == null)
                    throw new GuardException("Cannot process a null command.");
            }
        }
    }
}
