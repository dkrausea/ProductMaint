using System.Web.Mvc;

namespace RssWidgetPortableArea
{
    public class RssWidgetAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "RssWidget";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "RssWidget_default",
                "RssWidget/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
