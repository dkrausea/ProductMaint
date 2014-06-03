public class Person
{
  private string mFirstName = string.Empty;
  private string mLastName = string.Empty;

  public string FirstName
  {
    get { return mFirstName; }
    set { mFirstName = value; }
  }

  public string LastName
  {
    get { return mLastName; }
    set { mLastName = value; }
  }
}