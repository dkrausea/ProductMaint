using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Overloading_OverloadingSample2 : System.Web.UI.Page
{

  protected void btnGetDataSet1_Click(object sender, EventArgs e)
  {
    GetDataSetSQL();
  }
  protected void btnGetDataSet2_Click(object sender, EventArgs e)
  {
    GetDataSetCmd();
  }

  private void GetDataSetSQL()
  {
    string sql = null;

    sql = "SELECT * FROM oopUsers";

    grdUsers.DataSource = DataLayer2.GetDataSet(sql, AppConfig.ConnectString);
    grdUsers.DataBind();
  }

  private void GetDataSetCmd()
  {
    SqlCommand cmd = null;

    cmd = new SqlCommand("SELECT * FROM oopUsers");
    cmd.Connection = new SqlConnection(AppConfig.ConnectString);
    cmd.Connection.Open();

    grdUsers.DataSource = DataLayer2.GetDataSet(cmd);
    grdUsers.DataBind();

    cmd.Connection.Close();
    cmd.Connection.Dispose();
  }
}
