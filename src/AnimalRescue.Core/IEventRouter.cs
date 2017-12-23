using System;

namespace AnimalRescue.Core
{
    public interface IEventRouter
    {
        void Register<T>(Action<T> handler);
        void Dispatch(object eventMessage);
    }
}
