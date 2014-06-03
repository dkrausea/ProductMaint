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

partial class UserControls_ucCreditCardDisplay : System.Web.UI.UserControl
{

  public void SetUserData(PDSACreditCard cc)
  {
    SetUserData(cc, false);
  }

  public void SetUserData(PDSACreditCard cc, bool displayRealCCNumber)
  {
    lblCCType.Text = cc.CreditCardType;
    if (displayRealCCNumber)
    {
      lblCCNumber.Text = cc.CreditCardNumber;
    }
    else
    {
      if (cc.CreditCardNumber.Length > 4)
      {
        lblCCNumber.Text = "***************" + cc.CreditCardNumber.Substring(cc.CreditCardNumber.Length - 4);
      }
      else
      {
        lblCCNumber.Text = "***************";
      }
    }
    lblName.Text = cc.NameOnCard;
    lblExpDate.Text = cc.ExpMonth + "/" + cc.ExpYear;
    lblPostalCode.Text = cc.BillingPostalCode;
  }
}