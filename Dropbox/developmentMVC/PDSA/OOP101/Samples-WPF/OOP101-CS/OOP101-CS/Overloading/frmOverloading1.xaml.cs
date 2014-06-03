using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmOverloading1.xaml
  /// </summary>
  public partial class frmOverloading1 : Window
  {
    public frmOverloading1()
    {
      InitializeComponent();
    }

    private const string SQL = "SELECT * FROM oopUsers";

    private enum DataProviderEnum
    {
      SqlClient,
      OleDb,
    }

    protected void btnSqlClient_Click(object sender, RoutedEventArgs e)
    {
      LoadUsers(DataProviderEnum.SqlClient);
    }

    protected void btnOleDbClient_Click(object sender, RoutedEventArgs e)
    {
      LoadUsers(DataProviderEnum.OleDb);
    }

    // ** OVERLOADED **
    private void LoadUsers(string DataProvider)
    {
      switch (DataProvider.ToLower())
      {
        case "sqlclient":
          LoadUsers(DataProviderEnum.SqlClient);

          break;
        case "oledb":
          LoadUsers(DataProviderEnum.OleDb);

          break;
      }
    }

    private void LoadUsers(DataProviderEnum DataProvider)
    {
      DataTable dt = new DataTable();
      IDbDataAdapter da = null;

      switch (DataProvider)
      {
        case DataProviderEnum.SqlClient:
          da = new System.Data.SqlClient.SqlDataAdapter(SQL, AppConfig.ConnectString);
          ((SqlDataAdapter)da).Fill(dt);

          break;
        case DataProviderEnum.OleDb:
          da = new System.Data.OleDb.OleDbDataAdapter(SQL, AppConfig.ConnectStringOleDb);
          ((OleDbDataAdapter)da).Fill(dt);

          break;
      }

      lstUsers.DataContext = dt;
    }
  }
}
