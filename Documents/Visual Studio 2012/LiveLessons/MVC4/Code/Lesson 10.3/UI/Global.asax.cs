using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeCampServerLite.UI.App_Start;
using CodeCampServerLite.UI.Infrastructure.AutoMapper;
using Raven.Client;

namespace CodeCampServerLite.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            EndRequest += (sender, args) =>
            {
                using (var session = DependencyResolver.Current.GetService<IDocumentSession>())
                {
                    if (session == null)
                        return;

                    if (Server.GetLastError() != null)
                        return;

                    session.SaveChanges();
                }
            };

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            AutoMapperBootstrapper.Initialize();

            StructuremapMvc.Start();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            RavenDbConfig.FillData();
        }
    }
}