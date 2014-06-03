﻿using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web;

namespace RssWidgetPortableArea
{
    public static class HtmlHelperExtensions
    {
        public static void RssWidget(this HtmlHelper helper, string RssUrl)
        {
             helper.RenderAction("Index", "RssWidget", new { RssUrl, Area = "RssWidget" });
        }
    }
}