using System.Configuration;

public class AppConfig
{
  public static string ConnectString
  {
    get
    {
      return ConfigurationManager.ConnectionStrings["Sandbox"].ConnectionString;
    }
  }

  public static string ConnectStringOleDb
  {
    get
    {
      return ConfigurationManager.ConnectionStrings["SandboxOleDb"].ConnectionString;
    }
  }
}
