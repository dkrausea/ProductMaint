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

public partial class ClassSamples_UserSearch3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      Users bo = null;

      if (!(Page.IsPostBack))
      {
        bo = new Users();

        grdUsers.DataSource = bo.GetAllUsers();
        grdUsers.DataBind();
      }
    }
  protected void btnSearch_Click(object sender, EventArgs e)
  {
    Users bo = new Users();
    UsersSearch us = new UsersSearch();

    us.FirstName = txtFirstName.Text.Trim();
    us.LastName = txtLastName.Text.Trim();
    us.Email = txtEmailAddress.Text.Trim();

    grdUsers.DataSource = bo.GetUsersByFilter(us);
    grdUsers.DataBind();
  }
}
