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

public partial class Interfaces1_InterfaceSample1 : System.Web.UI.Page
{
  protected void btnTest1_Click(object sender, EventArgs e)
  {
    Test1();
  }

  private void Test1()
  {
    ITest it = null;

    it = new TestClass1();

    lblMsg.Text = it.InformUser();
  }

  protected void btnTest2_Click(object sender, EventArgs e)
  {
    Test2();
  }

  private void Test2()
  {
    ITest it = null;

    it = new TestClass2();

    lblMsg.Text = it.InformUser();
  }
}
