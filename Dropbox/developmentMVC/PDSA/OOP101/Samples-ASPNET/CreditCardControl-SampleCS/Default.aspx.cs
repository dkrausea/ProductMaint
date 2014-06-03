partial class _Default : System.Web.UI.Page
{
  protected void btnSubmit_Click(object sender, System.EventArgs e)
  {
    PDSACreditCard cc = null;

    cc = ucCC.GetUserData();

    Session["PDSACC"] = cc;

    Response.Redirect("CCDisplay.aspx");
  }
}