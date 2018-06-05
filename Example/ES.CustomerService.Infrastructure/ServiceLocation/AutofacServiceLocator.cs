using Autofac;
using Autofac.Core;
using ES.Core.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ES.CustomerService.Infrastructure.ServiceLocation
{
    public class AutofacServiceLocator : IServiceLocator
    {
        private IContainer _container;

        public AutofacServiceLocator(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(Type type)
        {
            return (T)_container.Resolve(type);
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public IEnumerable<object> GetInstances(Type type)
        {
            var enumerable = typeof(IEnumerable<>).MakeGenericType(type);
            return ((IEnumerable<object>)_container
                .Resolve(enumerable))
                .GroupBy(o => o.GetType().FullName)
                .Select(g => g.First());     
        }

        class InstanceTypeComparer : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {
                return x.GetType().FullName == y.GetType().FullName;
            }

            public int GetHashCode(object obj)
            {
                return obj.GetHashCode();
            }
        }


    }
}
