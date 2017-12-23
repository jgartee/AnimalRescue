using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalRescue.Core
{
    public interface IQueryProcessor
    {
        Task<object> ProcessAsync(IQuery query);
        Task<object> ProcessAsync(IQuery query, ClaimsPrincipal user);
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query, ClaimsPrincipal user);
    }
}
