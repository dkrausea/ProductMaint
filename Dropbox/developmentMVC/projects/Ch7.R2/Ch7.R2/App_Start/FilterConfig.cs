﻿using System.Web;
using System.Web.Mvc;

namespace Ch7.R2
{
   public class FilterConfig
   {
      public static void RegisterGlobalFilters( GlobalFilterCollection filters )
      {
         filters.Add(new HandleErrorAttribute());
      }
   }
}