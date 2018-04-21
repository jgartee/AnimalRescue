using System;

namespace AnimalRescue.Core.Exceptions
{
    public class QueryHandlerNotRegisteredException : Exception
    {
        private const string Msg = "Handler not registered for query, {0}";

        public QueryHandlerNotRegisteredException(IQuery query)
            : base(string.Format(Msg, query.GetType()))
        {
            Query = query;
        }

        public IQuery Query { get; }
    }
}
