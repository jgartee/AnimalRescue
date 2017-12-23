using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalRescue.Core
{
    public interface ICommandProcessor
    {
        Task<object> ProcessAsync(ICommand command);
        Task<object> ProcessAsync(ICommand command, ClaimsPrincipal user);
        Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command);
        Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command, ClaimsPrincipal user);
    }
}
