using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AnimalRescue.Core.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetAggregateEventTypes(this Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(t => typeof(IAggregateEvent).GetTypeInfo().IsAssignableFrom(t))
                .ToList();
        }
    }
}
