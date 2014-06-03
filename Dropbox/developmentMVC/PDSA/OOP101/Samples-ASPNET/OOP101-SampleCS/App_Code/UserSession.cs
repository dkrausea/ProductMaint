using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for UserSession
/// </summary>
public class UserSession
{
	public UserSession()
	{
	}

  public static string MyValue
  {
    get { return HttpContext.Current.Session["MyValue"].ToString() ; }
    set { HttpContext.Current.Session["MyValue"] = value; }
  }

  public static int MyIntValue
  {
    get { return Convert.ToInt32(HttpContext.Current.Session["MyIntValue"]); }
    set { HttpContext.Current.Session["MyValue"] = value; }
  }
}
