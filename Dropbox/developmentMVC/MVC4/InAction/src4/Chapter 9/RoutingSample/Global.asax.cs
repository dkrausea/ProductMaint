using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RoutingSample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            /*  Desired URL schema:
             * 1.  example.com/                     home page
             * 2.  example.com/privacy              static page containing privacy policy
             * 3.  example.com/products             show a list of the products
             * 4.  example.com/products/<product code>	    Shows a product detail page for the relevant <product code>
             * 5.  example.com/products/<product code>/buy	Add the relevant product to the shopping basket
             * 6.  example.com/basket	            Shows the current users shopping basket
             * 7.  example.com/checkout	            Starts the checkout process for the current user
             * 8.  example.com/404                  show a friendly 404 page
             */
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // If no route parameters are specified, default to the home controller
            routes.MapRoute("home", "", new { controller = "Home", action = "Index" });

            // The /404 url goes to the NotFound page.
            routes.MapRoute("404", "404", new { controller = "Error", action = "NotFound" });

            // Privacy policy page static route.
            routes.MapRoute("privacy_policy", "privacy", new { controller = "Home", action = "Privacy" });

            // Dynamic route for product codes.
            routes.MapRoute("product", "products/{productCode}/{action}",
                            new { controller = "Catalog", action = "Show" },
                            new { productCode = new NotEqualConstraint("ByCategory") }); //exclude the ProductsByCategory page. 
            // Instead of the custom constraint we could also use a RegEx:
            // new{ productCode = "(?!ByCategory).*"}

            // Product list page.
            routes.MapRoute("products", "products", new { controller = "Catalog", action = "index" });

            // Catalog page with action constraint
            routes.MapRoute("catalog", "{action}",
                            new { controller = "Catalog" },
                            new { action = @"basket|checkout" });

            // Interop with Web Forms.
            routes.MapPageRoute(
                "ProductsByCategory",
                "products/ByCategory/{category}",
                "~/ProductsByCategory.aspx",
                checkPhysicalUrlAccess: true,
                defaults: new RouteValueDictionary(new { category = "All" })
            );

            // Anything else that doesn't match the above routing structure is treated as a 404.
            routes.MapRoute("404-catch-all", "{*catchall}", new { Controller = "Error", Action = "NotFound" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();
        }
    }
}