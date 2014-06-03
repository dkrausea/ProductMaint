using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CodeCampServerLite.UI.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString EmbedCurrentPage(
            this HtmlHelper helper,
            ViewContext viewContext)
        {
            var controllerName = viewContext.RouteData.Values["controller"];
            var actionName = viewContext.RouteData.Values["action"];
            var value = controllerName + "." + actionName;
            return helper.Hidden("controller-action", value);
        }

        public static MvcHtmlString Submit(this HtmlHelper helper, string value = "Save")
        {
            return new MvcHtmlString("<input id=\"Submit\" type=\"submit\" value=\"" + value + "\" />");
        }
    }

}