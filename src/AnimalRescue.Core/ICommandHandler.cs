using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalRescue.Core
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ClaimsPrincipal user);
    }

    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> HandleAsync(TCommand command, ClaimsPrincipal user);
    }
}
