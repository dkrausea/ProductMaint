using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StructureMap;
using System.Linq;

namespace ControllerFactoryExamples
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            var instance = ObjectFactory.TryGetInstance(serviceType);
            
            if(instance == null && !serviceType.IsAbstract && !serviceType.IsInterface)
            {
                instance = ObjectFactory.GetInstance(serviceType);
            }

            return instance;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
        }
    }
}