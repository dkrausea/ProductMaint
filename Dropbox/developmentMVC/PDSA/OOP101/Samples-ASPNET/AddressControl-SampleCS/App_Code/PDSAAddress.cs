using System.Data;
using System.Configuration;
using System;

[Serializable()]
public class PDSAAddress
{
  public enum PDSAAddressTypeEnum : int
  {
    US,
    Canadian,
    UK,
    Other,
  }

  private Guid mObjectId = Guid.NewGuid();
  private PDSAAddressTypeEnum mType = PDSAAddressTypeEnum.US;
  private string mAddress1 = string.Empty;
  private string mAddress2 = string.Empty;
  private string mAddress3 = string.Empty;
  private string mCity = string.Empty;
  private string mVillage = string.Empty;
  private int mStateId = int.MinValue;
  private string mStateCode = string.Empty;
  private string mStateName = string.Empty;
  private int mCountryId = int.MinValue;
  private string mCountryCode = string.Empty;
  private string mCountryName = string.Empty;
  private string mPostalCode = string.Empty;
  private string mPostalCodeExt = string.Empty;

  public Guid ObjectId
  {
    get { return this.mObjectId; }
  }

  public PDSAAddressTypeEnum Type
  {
    get { return this.mType; }
    set { this.mType = value; }
  }

  public string Address1
  {
    get { return this.mAddress1; }
    set { this.mAddress1 = value; }
  }

  public string Address2
  {
    get { return this.mAddress2; }
    set { this.mAddress2 = value; }
  }

  public string Address3
  {
    get { return this.mAddress3; }
    set { this.mAddress3 = value; }
  }

  public string City
  {
    get { return this.mCity; }
    set { this.mCity = value; }
  }

  public string Village
  {
    get { return this.mVillage; }
    set { this.mVillage = value; }
  }

  public int StateId
  {
    get { return this.mStateId; }
    set { this.mStateId = value; }
  }

  public string StateCode
  {
    get { return this.mStateCode; }
    set { this.mStateCode = value; }
  }

  public string StateName
  {
    get { return this.mStateName; }
    set { this.mStateName = value; }
  }

  public int CountryId
  {
    get { return this.mCountryId; }
    set { this.mCountryId = value; }
  }

  public string CountryCode
  {
    get { return this.mCountryCode; }
    set { this.mCountryCode = value; }
  }

  public string CountryName
  {
    get { return this.mCountryName; }
    set { this.mCountryName = value; }
  }

  public string PostalCode
  {
    get { return this.mPostalCode; }
    set { this.mPostalCode = value; }
  }

  public string PostalCodeExt
  {
    get { return this.mPostalCodeExt; }
    set { this.mPostalCodeExt = value; }
  }

  public virtual bool Validate()
  {
    bool isValid = true;

    //  Require Address1
    if (this.mAddress1.Length == 0)
    {
      isValid = false;
    }

    //  Require City
    if (this.mCity.Length == 0)
    {
      isValid = false;
    }

    // Require State for Canada and US
    if (this.mType == PDSAAddressTypeEnum.Canadian | this.mType == PDSAAddressTypeEnum.US)
    {
      if (this.mStateName.Length == 0 & this.mStateCode.Length == 0 & this.mStateId > 0)
      {
        isValid = false;
      }
    }

    //  Require Postal Code
    if (this.mPostalCode.Length == 0)
    {
      isValid = false;
    }

    return isValid;
  }


  public string GetFullAddress()
  {
    // Returns an strAddr in the following format
    // 1234 Street
    // PO Box 1234
    // Route(4)
    // City, State 90210-1234

    string addr = null;

    addr = this.mAddress1;

    if (this.mAddress2.Length > 0)
    {
      addr += "\r\n" + this.mAddress2;
    }

    if (this.mAddress3.Length > 0)
    {
      addr += "\r\n" + this.mAddress3;
    }

    addr += "\r\n" + this.mCity;

    if (this.mType != PDSAAddressTypeEnum.Other)
    {
      if (this.mStateName.Trim() != "")
      {
        addr += ", " + this.mStateName;
      }
      else
      {
        addr += ", " + this.mStateCode;
      }
    }

    addr += "  " + this.mPostalCode;

    if (this.mType != PDSAAddressTypeEnum.Other & this.mPostalCodeExt.Trim() != string.Empty)
    {
      addr += " - " + this.mPostalCodeExt;
    }

    return addr;
  }

  public override string ToString()
  {
    return GetFullAddress();
  }
}