using System.Data;
using System.Configuration;
using System;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

partial class BusinessControls_ucAddress : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!(Page.IsPostBack))
    {
      this.InitControlVisiblity();
      LoadDropDowns();
    }
  }

  public void LoadDropDowns()
  {
    if (ddlCountry.Items.Count == 0)
    {
      CountryLoad();
      ShowCountry();
      ShowDetails(PDSAAddress.PDSAAddressTypeEnum.US);
    }
  }

  private void CountryLoad()
  {
    ddlCountry.DataTextField = "sName";
    ddlCountry.DataValueField = "sCode";
    ddlCountry.DataSource = PDSADataCommon.GetCountries().Tables[0];
    ddlCountry.DataBind();
  }

  private void StateLoad()
  {
    ddlStateProvince.DataTextField = "StateName";
    ddlStateProvince.DataValueField = "StateCode";
    this.ddlStateProvince.DataSource = PDSADataCommon.GetUSStates().Tables[0];
    this.ddlStateProvince.DataBind();
  }

  private void InitControlVisiblity()
  {
    this.divPDSAAddrAddress3.Visible = false;
    this.divPDSAAddrState.Visible = true;
    this.divPDSAAddrVillage.Visible = false;
    this.lblZipHypen.Visible = true;
    this.txtZipExension.Visible = true;
    this.lblZipPostal.Text = "Zip Code";
    this.lblStateProvince.Text = "State";
    this.lblZipHypen.Visible = true;
    this.txtZipExension.Visible = true;
  }

  protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.ShowDetails(this.AddressType);
  }

  private PDSAAddress.PDSAAddressTypeEnum AddressType
  {
    get
    {
      if (this.ddlCountry.SelectedItem.Value == "USA")
      {
        return PDSAAddress.PDSAAddressTypeEnum.US;
      }
      else if (this.ddlCountry.SelectedItem.Value == "CAN")
      {
        return PDSAAddress.PDSAAddressTypeEnum.Canadian;
      }
      else if (this.ddlCountry.SelectedItem.Value == "GBR")
      {
        return PDSAAddress.PDSAAddressTypeEnum.UK;
      }
      else
      {
        return PDSAAddress.PDSAAddressTypeEnum.Other;
      }
    }
  }

  public void ShowCountry()
  {
    this.divPDSAAddrCountry.Visible = true;
    this.divPDSAAddrDetails.Visible = true;
  }

  public void ShowDetails(PDSAAddress.PDSAAddressTypeEnum addressType)
  {
    this.divPDSAAddrDetails.Visible = true;

    ddlStateProvince.DataSource = null;
    ddlStateProvince.Items.Clear();
    if (this.AddressType == PDSAAddress.PDSAAddressTypeEnum.Other)
    {
      this.divPDSAAddrVillage.Visible = false;
      this.lblZipPostal.Text = "Postal Code";
      this.divPDSAAddrAddress3.Visible = true;
      this.divPDSAAddrState.Visible = false;
      this.lblZipHypen.Visible = false;
      this.txtZipExension.Visible = false;
      rfvStateProvince.Enabled = false;
    }
    else if (this.AddressType == PDSAAddress.PDSAAddressTypeEnum.UK)
    {
      this.divPDSAAddrVillage.Visible = true;
      this.lblZipPostal.Text = "Postal Code";
      this.lblZipHypen.Visible = false;
      this.txtZipExension.Visible = false;
      this.divPDSAAddrState.Visible = false;
      rfvStateProvince.Enabled = false;
    }
    else if (this.AddressType == PDSAAddress.PDSAAddressTypeEnum.Canadian)
    {
      this.divPDSAAddrVillage.Visible = false;
      this.lblZipPostal.Text = "Postal Code";
      this.lblStateProvince.Text = "Province";
      this.lblZipHypen.Visible = false;
      this.txtZipExension.Visible = false;
      ddlStateProvince.DataTextField = "Name";
      ddlStateProvince.DataValueField = "PostalAbbr";
      this.ddlStateProvince.DataSource = PDSADataCommon.GetCanadianProvinces().Tables[0];
      this.ddlStateProvince.DataBind();
      rfvStateProvince.Enabled = false;
    }
    else if (this.AddressType == PDSAAddress.PDSAAddressTypeEnum.US)
    {
      this.divPDSAAddrAddress3.Visible = false;
      this.divPDSAAddrState.Visible = true;
      this.divPDSAAddrVillage.Visible = false;
      this.lblZipHypen.Visible = true;
      this.txtZipExension.Visible = true;
      this.lblZipPostal.Text = "Zip Code";
      this.lblStateProvince.Text = "State";
      this.lblZipHypen.Visible = true;
      this.txtZipExension.Visible = true;
      ddlStateProvince.DataTextField = "StateName";
      ddlStateProvince.DataValueField = "StateCode";
      this.ddlStateProvince.DataSource = PDSADataCommon.GetUSStates().Tables[0];
      this.ddlStateProvince.DataBind();
      rfvStateProvince.Enabled = true;
    }
  }

  public PDSAAddress GetUserData()
  {
    PDSAAddress addr = new PDSAAddress();

    addr.Address1 = this.txtAddress1.Text;
    addr.Address2 = this.txtAddress2.Text;
    addr.Address3 = this.txtAddress3.Text;
    addr.City = this.txtCity.Text;

    if (divPDSAAddrState.Visible)
    {
      addr.StateCode = this.ddlStateProvince.SelectedItem.Value;
      addr.StateName = this.ddlStateProvince.SelectedItem.Text;
    }
    else
    {
      addr.StateCode = "";
      addr.StateName = "";
    }
    addr.CountryCode = this.ddlCountry.SelectedItem.Value;
    addr.CountryName = this.ddlCountry.SelectedItem.Text;
    addr.PostalCode = this.txtZipPostal.Text;

    if (this.txtZipExension.Text.Length > 0)
    {
      addr.PostalCodeExt = this.txtZipExension.Text;
    }
    addr.Type = this.AddressType;

    return addr;
  }

  public void SetUserData(PDSAAddress addr)
  {

    this.txtAddress1.Text = addr.Address1;
    this.txtAddress2.Text = addr.Address2;
    this.txtAddress3.Text = addr.Address3;
    this.txtCity.Text = addr.City;

    if (addr.StateCode.Trim() != "")
    {
      ddlStateProvince.SelectedIndex = -1;
      PDSAWebList.DropDownFindByValue(ref ddlStateProvince, addr.StateCode);
    }
    else if (addr.StateName.Trim() != "")
    {
      ddlStateProvince.SelectedIndex = -1;
      PDSAWebList.DropDownFindByText(ref ddlStateProvince, addr.StateName);
    }
    if (addr.CountryCode.Trim() != "")
    {
      ddlCountry.SelectedIndex = -1;
      PDSAWebList.DropDownFindByValue(ref ddlCountry, addr.CountryCode);
    }
    else if (addr.CountryName.Trim() != "")
    {
      ddlCountry.SelectedIndex = -1;
      PDSAWebList.DropDownFindByValue(ref ddlCountry, addr.CountryName);
    }
    this.txtZipPostal.Text = addr.PostalCode;

    this.txtZipExension.Text = addr.PostalCodeExt;
  }
}