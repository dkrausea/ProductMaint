using System;
using System.Web.Mvc;
using StructureMap;

namespace CodeCampServerLite.UI.Infrastructure.StructureMap
{
    public static class StructureMapConfiguration
    {
        public static IContainer BuildContainer()
        {
            return new Container(cfg =>
            {
                cfg.Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                    s.LookForRegistries();

                    s.AddAllTypesOf<IModelBinderProvider>();
                });
            });
        }
    }
}