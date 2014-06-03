using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmEnums.xaml
  /// </summary>
  public partial class frmEnums : Window
  {
    public frmEnums()
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

    private void btnOleDbClient_Click(object sender, RoutedEventArgs e)
    {
      LoadUsers(DataProviderEnum.OleDb);
    }

    private void LoadUsers(DataProviderEnum DataProvider)
    {
      DataTable dt = new DataTable();
      IDbDataAdapter da = null;

      switch (DataProvider)
      {
        case DataProviderEnum.SqlClient:
          da = new System.Data.SqlClient.SqlDataAdapter(SQL, 
            AppConfig.ConnectString);
          ((SqlDataAdapter)da).Fill(dt);

          break;
        case DataProviderEnum.OleDb:
          da = new System.Data.OleDb.OleDbDataAdapter(SQL, 
            AppConfig.ConnectStringOleDb);
          ((OleDbDataAdapter)da).Fill(dt);

          break;
      }

      lstUsers.DataContext = dt;
    }

  }
}
