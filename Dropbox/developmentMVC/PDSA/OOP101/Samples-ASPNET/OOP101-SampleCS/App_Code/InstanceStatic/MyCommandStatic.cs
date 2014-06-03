public class MyCommandStatic
{
  private static string mCommandText;

  public static string CommandText
  {
    get { return mCommandText; }
    set { mCommandText = value; }
  }
}