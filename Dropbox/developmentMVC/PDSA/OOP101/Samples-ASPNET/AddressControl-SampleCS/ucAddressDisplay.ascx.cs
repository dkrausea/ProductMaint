using System.Text;

partial class UserControls_ucAddressDisplay : System.Web.UI.UserControl
{
  public void SetUserData(PDSAAddress addr)
  {
    StringBuilder sb = new StringBuilder(1024);

    sb.Append(addr.Address1);
    sb.Append("<br />");
    if (addr.Address2.Trim() != string.Empty)
    {
      sb.Append(addr.Address2);
      sb.Append("<br />");
    }
    if (addr.Address3.Trim() != string.Empty)
    {
      sb.Append(addr.Address3);
      sb.Append("<br />");
    }
    if (addr.City.Trim() != string.Empty)
    {
      sb.Append(addr.City);
    }
    if (addr.Village.Trim() != string.Empty)
    {
      sb.Append(addr.Village);
    }
    if (addr.StateName.Trim() != string.Empty)
    {
      sb.Append(", " + addr.StateName);
    }
    else if (addr.StateCode.Trim() != string.Empty)
    {
      sb.Append(", " + addr.StateCode);
    }
    if (addr.PostalCode.Trim() != string.Empty)
    {
      sb.Append(" " + addr.PostalCode);
      if (addr.PostalCodeExt != string.Empty)
      {
        sb.Append("-" + addr.PostalCodeExt);
      }
      sb.Append("<br />");
    }
    if (addr.CountryName.Trim() != string.Empty)
    {
      sb.Append(addr.CountryName);
      sb.Append("<br />");
    }
    else if (addr.CountryCode.Trim() != string.Empty)
    {
      sb.Append(addr.CountryCode);
      sb.Append("<br />");
    }

    lblAddress.Text = sb.ToString();
  }
}