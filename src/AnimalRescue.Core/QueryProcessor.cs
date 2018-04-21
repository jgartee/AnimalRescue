using System.Security.Claims;
using System.Threading.Tasks;
using AnimalRescue.Core.Exceptions;
using AnimalRescue.Core.Extensions;
using CommonServiceLocator;

namespace AnimalRescue.Core
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceLocator _serviceLocator;

        public QueryProcessor(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<object> ProcessAsync(IQuery query)
        {
            return await ProcessAsync(query, ClaimsPrincipal.Current);
        }

        public async Task<object> ProcessAsync(IQuery query, ClaimsPrincipal user)
        {
            Guard.IsNotNullQuery(query);

            var queryReturnType = query.GetQueryReturnType();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), queryReturnType);
            dynamic handler = _serviceLocator.GetInstance(handlerType);

            if (handler == null)
                throw new QueryHandlerNotRegisteredException(query);

            return await handler.HandleAsync((dynamic)query);
        }

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query)
        {
            return await ProcessAsync(query, ClaimsPrincipal.Current);
        }

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query, ClaimsPrincipal user)
        {
            Guard.IsNotNullQuery(query);

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceLocator.GetInstance(handlerType);

            if (handler == null)
                throw new QueryHandlerNotRegisteredException(query);

            return await handler.HandleAsync((dynamic)query, user);
        }

        private static class Guard
        {
            public static void IsNotNullQuery(IQuery query)
            {
                if (query == null)
                    throw new GuardException("Cannot process a null query.");
            }
        }
    }
}
