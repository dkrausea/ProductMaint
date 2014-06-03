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

partial class UserControls_ucCreditCard : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!(Page.IsPostBack))
    {
      CardTypesLoad();
      MonthLoad();
      YearLoad();
    }
  }

  private void CardTypesLoad()
  {
    DataSet ds = new DataSet();

    ds.ReadXml(Server.MapPath("~/Xml-Common/CreditCardTypes.xml"));

    ddlCreditCards.DataTextField = "Name";
    ddlCreditCards.DataValueField = "Name";
    ddlCreditCards.DataSource = ds;
    ddlCreditCards.DataBind();
  }

  private void MonthLoad()
  {
    int index = 0;

    for (index = 1; index <= 12; index++)
    {
      ddlMonth.Items.Add(index.ToString() + "-" + GetMonthName(index));
    }
  }

  private void YearLoad()
  {
    int index = 0;

    for (index = DateTime.Now.Year; index <= (DateTime.Now.Year + 12); index++)
    {
      ddlYear.Items.Add(index.ToString());
    }
  }


  private string GetMonthName(int Value)
  {
    System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
    string[] arr = null;

    arr = dtfi.MonthNames;

    return arr[Value - 1];
  }

  public PDSACreditCard GetUserData()
  {
    PDSACreditCard cc = new PDSACreditCard();
    string ccNum = null;

    ccNum = txtCardNumber.Text.Trim();
    ccNum = ccNum.Replace(" ", "");
    ccNum = ccNum.Replace("-", "");
    ccNum = ccNum.Replace("/", "");
    ccNum = ccNum.Replace(@"\", "");
    ccNum = ccNum.Replace(".", "");

    cc.CreditCardNumber = ccNum;
    cc.CreditCardType = ddlCreditCards.SelectedItem.Text;
    cc.CVCode = txtCVCode.Text;
    cc.NameOnCard = txtName.Text;
    cc.ExpMonth = ddlMonth.SelectedItem.Text;
    cc.ExpYear = ddlYear.SelectedItem.Text;
    cc.BillingPostalCode = txtZipCode.Text;

    return cc;
  }

  public void SetUserData(PDSACreditCard cc)
  {
    string ccNum = null;

    ccNum = cc.CreditCardNumber.Trim();

    if (ccNum.Length > 4)
    {
      txtCardNumber.Text = "**********" + ccNum.Substring(ccNum.Length - 4);
    }
    else
    {
      if (ccNum.Length == 0)
      {
        txtCardNumber.Text = "";
      }
      else
      {
        txtCardNumber.Text = "*********************";
      }
    }
    PDSAWebList.DropDownFindByText(ref ddlCreditCards, cc.CreditCardType);
    txtName.Text = cc.NameOnCard;
    txtCVCode.Text = cc.CVCode;
    PDSAWebList.DropDownFindByText(ref ddlMonth, cc.ExpMonth);
    PDSAWebList.DropDownFindByText(ref ddlYear, cc.ExpYear);
    txtZipCode.Text = cc.BillingPostalCode;
  }
}