public class UsersSearch
{
  private string mFirstName = string.Empty;
  private string mLastName = string.Empty;
  private string mEmail = string.Empty;

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

  public string Email
  {
    get { return mEmail; }
    set { mEmail = value; }
  }
}