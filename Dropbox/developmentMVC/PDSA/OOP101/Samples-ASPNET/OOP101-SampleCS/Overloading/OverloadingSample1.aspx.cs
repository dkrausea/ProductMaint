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

public partial class Overloading_OverloadingSample1 : System.Web.UI.Page
{
  private const string SQL = "SELECT * FROM oopUsers";

  private enum DataProviderEnum
  {
    SqlClient,
    OleDb,
  }

  protected void btnSqlClient_Click(object sender, EventArgs e)
  {
    LoadUsers(DataProviderEnum.SqlClient);
  }
  
  protected void btnOleDb_Click(object sender, EventArgs e)
  {
    LoadUsers(DataProviderEnum.OleDb);
  }

  // ** OVERLOADED **
  private void LoadUsers(string DataProvider)
  {
    switch (DataProvider.ToLower())
    {
      case "sqlclient":
        LoadUsers(DataProviderEnum.SqlClient);

        break;
      case "oledb":
        LoadUsers(DataProviderEnum.OleDb);

        break;
    }
  }

  private void LoadUsers(DataProviderEnum DataProvider)
  {
    DataSet ds = new DataSet();
    IDbDataAdapter da = null;

    switch (DataProvider)
    {
      case DataProviderEnum.SqlClient:
        da = new System.Data.SqlClient.SqlDataAdapter(SQL, AppConfig.ConnectString);

        break;
      case DataProviderEnum.OleDb:
        da = new System.Data.OleDb.OleDbDataAdapter(SQL, ConfigurationManager.ConnectionStrings["SandboxOleDb"].ConnectionString);

        break;
    }

    da.Fill(ds);

    grdUsers.DataSource = ds;
    grdUsers.DataBind();
  }

}
