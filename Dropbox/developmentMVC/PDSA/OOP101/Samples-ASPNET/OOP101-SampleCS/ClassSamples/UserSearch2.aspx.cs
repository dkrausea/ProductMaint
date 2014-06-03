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

public partial class ClassSamples_UserSearch2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!(Page.IsPostBack))
      {
        DataSet ds = null;

        ds = DataLayer.GetDataSet("SELECT * FROM oopUsers", AppConfig.ConnectString);

        grdUsers.DataSource = ds;
        grdUsers.DataBind();
      }
    }
  protected void btnSearch_Click(object sender, EventArgs e)
  {
    string sql = string.Empty;
    string where = " WHERE ";
    DataSet ds = null;

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

    ds = DataLayer.GetDataSet("SELECT * FROM oopUsers " + sql, AppConfig.ConnectString);

    grdUsers.DataSource = ds;
    grdUsers.DataBind();
  }
}
