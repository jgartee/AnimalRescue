using System;

namespace AnimalRescue.Core
{
    public interface IServiceLocatorx
    {
        object GetInstance(Type type);
    }
}
