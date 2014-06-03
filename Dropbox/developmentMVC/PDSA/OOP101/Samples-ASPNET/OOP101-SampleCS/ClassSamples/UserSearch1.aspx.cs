using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ClassSamples_UserSearch1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!(Page.IsPostBack))
      {
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;

        da = new SqlDataAdapter("SELECT * FROM oopUsers", @"Server=Localhost;Database=Sandbox;uid=sa;pwd=P@ssw0rd");
        da.Fill(ds);

        grdUsers.DataSource = ds;
        grdUsers.DataBind();
      }
    }
  protected void btnSearch_Click(object sender, EventArgs e)
  {
    string sql = string.Empty;
    string where = " WHERE ";
    DataSet ds = new DataSet();
    SqlDataAdapter da = null;

    if (txtFirstName.Text.Trim() != string.Empty)
    {
      sql += where + " FirstName LIKE '" + txtFirstName.Text + "%'";
      where = " AND ";
    }
    if (txtLastName.Text.Trim() != string.Empty)
    {
      sql += where + " LastName LIKE '" + txtLastName.Text + "%'";
      where = " AND ";
    }
    if (txtEmailAddress.Text.Trim() != string.Empty)
    {
      sql += where + " Email LIKE '%" + txtEmailAddress.Text + "%'";
      where = " AND ";
    }

    da = new SqlDataAdapter("SELECT * FROM oopUsers " + sql, @"Server=Localhost;Database=Sandbox;uid=sa;pwd=P@ssw0rd");
    da.Fill(ds);

    grdUsers.DataSource = ds;
    grdUsers.DataBind();
  }
}
