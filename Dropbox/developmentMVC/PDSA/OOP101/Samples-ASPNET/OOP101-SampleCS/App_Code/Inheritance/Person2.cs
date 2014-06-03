public class Person2
{
  private string mFirstName = string.Empty;
  private string mLastName = string.Empty;
  private string mFullName = string.Empty;

  public string FirstName
  {
    get { return mFirstName; }
    set
    {
      mFirstName = value;
      //  Call Protected Method                
      CreateFullName();
    }
  }

  public string LastName
  {
    get { return mLastName; }
    set
    {
      mLastName = value;
      //  Call Protected Method
      CreateFullName();
    }
  }

  public string FullName
  {
    get { return mFullName; }
    set { mFullName = value; }
  }

  protected virtual void CreateFullName()
  {
    mFullName = mLastName + ", " + mFirstName;
  }
}