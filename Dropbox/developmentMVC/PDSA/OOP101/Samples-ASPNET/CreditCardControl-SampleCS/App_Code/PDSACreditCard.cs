using System;

[Serializable()]
public class PDSACreditCard
{
  private string mCreditCardType = "Visa";
  private string mNameOnCard = string.Empty;
  private string mCreditCardNumber = string.Empty;
  private string mExpMonth = string.Empty;
  private string mExpYear = string.Empty;
  private string mCVCode = string.Empty;
  private string mBillingPostalCode = string.Empty;

  public string BillingPostalCode
  {
    get { return mBillingPostalCode; }
    set { mBillingPostalCode = value; }
  }

  public string CreditCardType
  {
    get { return mCreditCardType; }
    set { mCreditCardType = value; }
  }

  public string NameOnCard
  {
    get { return mNameOnCard; }
    set { mNameOnCard = value; }
  }

  public string CreditCardNumber
  {
    get { return mCreditCardNumber; }
    set { mCreditCardNumber = value; }
  }

  public string ExpMonth
  {
    get { return mExpMonth; }
    set { mExpMonth = value; }
  }

  public string ExpYear
  {
    get { return mExpYear; }
    set { mExpYear = value; }
  }

  public string CVCode
  {
    get { return mCVCode; }
    set { mCVCode = value; }
  }
}