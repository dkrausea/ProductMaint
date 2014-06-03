using System;
using System.Web.Mvc;
using SmartBindersExample.Models;

namespace SmartBindersExample.Helpers
{
    public class EntityModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            ValueProviderResult value = 
                bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (value == null)
                return null;

            if (string.IsNullOrEmpty(value.AttemptedValue))
                return null;

            int entityId;
			
            if(! int.TryParse(value.AttemptedValue, 
                out entityId)) 
            {
                return null;
            }

            Type repositoryType = typeof(IRepository<>)
                .MakeGenericType(bindingContext.ModelType);
            var repository = (IRepository)ServiceLocator.Resolve(repositoryType);

            Entity entity = repository.GetById(entityId);

            return entity;
        }
    }
}