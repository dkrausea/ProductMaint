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

public partial class ClassSamples_InstanceStaticSample : System.Web.UI.Page
{
  protected void btnInstance_Click(object sender, EventArgs e)
  {
    MyCommandInstance cmd1 = new MyCommandInstance();
    MyCommandInstance cmd2 = new MyCommandInstance();

    cmd1.CommandText = "SELECT * FROM Products";
    cmd2.CommandText = "SELECT * FROM Users";

    System.Diagnostics.Debugger.Break();
    //  Look at each CommandText property
  }

  protected void btnStatic_Click(object sender, EventArgs e)
  {
    //  The following does not make sense
    MyCommandStatic cmd1 = new MyCommandStatic();
    MyCommandStatic cmd2 = new MyCommandStatic();
    // cmd1.CommandText = "SELECT * FROM Products" ' Not valid

    MyCommandStatic.CommandText = "SELECT * FROM Products";
    MyCommandStatic.CommandText = "SELECT * FROM Users";

    System.Diagnostics.Debugger.Break();
    //  Look at each CommandText property
  }
}
