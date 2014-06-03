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

public partial class Inheritance_InheritanceSample2 : WebBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    lblMsg.Text = "Hello World";
  }

  protected override void OnPreInit(EventArgs e)
  {
    this.Theme = "Blue";
  }
}
