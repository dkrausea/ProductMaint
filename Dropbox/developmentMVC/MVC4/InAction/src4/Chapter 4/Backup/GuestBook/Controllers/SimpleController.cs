using System.Web.Mvc;
using System.Web.Routing;

namespace Guestbook.Controllers
{
    public class SimpleController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            requestContext.HttpContext
                .Response.Write("<h1>Welcome to the Guest Book.</h1>");
        }
    }

    public class AnotherSimpleController : Controller
    {
        public void Index()
        {
            Response.Write("<h1>Welcome to the Guest Book.</h1>");
        }

        public string AnotherAction()
        {
            return "<h1>Welcome to the Guest Book.</h1>";
        }
    }
}