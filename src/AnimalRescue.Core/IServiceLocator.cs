using System;

namespace AnimalRescue.Core
{
    public interface IServiceLocator
    {
        object GetInstance(Type type);
    }
}
