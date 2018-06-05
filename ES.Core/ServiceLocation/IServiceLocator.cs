using System;
using System.Collections.Generic;

namespace ES.Core.ServiceLocation
{
    public interface IServiceLocator
    {
        T Resolve<T>() where T : class;      
        T Resolve<T>(Type type);
        object Resolve(Type type);
        IEnumerable<object> GetInstances(Type type);
    }
}