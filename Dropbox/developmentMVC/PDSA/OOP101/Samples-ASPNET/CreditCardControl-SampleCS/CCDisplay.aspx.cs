using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

partial class CCDisplay : System.Web.UI.Page
{
  protected void Page_Load(object sender, System.EventArgs e)
  {
    PDSACreditCard cc = null;

    if (Session["PDSACC"] != null)
    {
      cc = ((PDSACreditCard)(Session["PDSACC"]));

      ucCCDisplay.SetUserData(cc);
    }
  }
}