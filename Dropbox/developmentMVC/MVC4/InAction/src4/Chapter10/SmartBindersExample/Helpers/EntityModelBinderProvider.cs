using System;
using System.Web.Mvc;
using SmartBindersExample.Models;

namespace SmartBindersExample.Helpers
{
public class EntityModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(Type modelType)
    {
        if (!typeof(Entity).IsAssignableFrom(modelType))
            return null;

        return new EntityModelBinder();
    }
}
}