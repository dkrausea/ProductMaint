using System.Web;
using System.Web.UI.WebControls;

public class PDSAWebList
{
  public static void DropDownFindByText(ref DropDownList ddl, string value)
  {
    ListItem di = null;

    di = ddl.Items.FindByText(value);
    if (!((di == null)))
    {
      di.Selected = true;
    }
  }

  public static void DropDownFindByValue(ref DropDownList ddl, int value)
  {
    ListItem di = null;

    di = ddl.Items.FindByValue(value.ToString());
    if (!((di == null)))
    {
      di.Selected = true;
    }
  }

  public static void DropDownFindByValue(ref DropDownList ddl, string value)
  {
    ListItem di = null;

    di = ddl.Items.FindByValue(value);
    if (!((di == null)))
    {
      di.Selected = true;
    }
  }
}