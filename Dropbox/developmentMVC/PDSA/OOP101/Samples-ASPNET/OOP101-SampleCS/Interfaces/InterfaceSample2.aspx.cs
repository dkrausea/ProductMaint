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

public partial class Interfaces2_InterfaceSample2 : System.Web.UI.Page
{
  private const string SQL = "SELECT * FROM oopUsers";

  protected void btnSqlClient_Click(object sender, EventArgs e)
  {
    LoadUsers("SqlClient");
  }
  protected void btnOleDb_Click(object sender, EventArgs e)
  {
    LoadUsers("OleDb");
  }

  private void LoadUsers(string DataProvider)
  {
    DataSet ds = new DataSet();
    IDbDataAdapter da = null;

    switch (DataProvider)
    {
      case "SqlClient":
        da = new System.Data.SqlClient.SqlDataAdapter(SQL, AppConfig.ConnectString);

        break;
      case "OleDb":
        da = new System.Data.OleDb.OleDbDataAdapter(SQL, ConfigurationManager.ConnectionStrings["SandboxOleDb"].ConnectionString);

        break;
    }

    da.Fill(ds);

    grdUsers.DataSource = ds;
    grdUsers.DataBind();
  }
}
