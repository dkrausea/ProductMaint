using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmInterface2.xaml
  /// </summary>
  public partial class frmInterface2 : Window
  {
    public frmInterface2()
    {
      InitializeComponent();
    }

    private const string SQL = "SELECT * FROM oopUsers";

    protected void btnSqlClient_Click(object sender, RoutedEventArgs e)
    {
      LoadUsers("SqlClient");
    }

    protected void btnOleDbClient_Click(object sender, RoutedEventArgs e)
    {
      LoadUsers("OleDb");
    }

    private void LoadUsers(string DataProvider)
    {
      DataTable dt = new DataTable();
      IDbDataAdapter da = null;

      switch (DataProvider)
      {
        case "SqlClient":
          da = new System.Data.SqlClient.SqlDataAdapter(SQL, AppConfig.ConnectString);
          ((SqlDataAdapter)da).Fill(dt);

          break;
        case "OleDb":
          da = new System.Data.OleDb.OleDbDataAdapter(SQL,
            AppConfig.ConnectStringOleDb);
          ((OleDbDataAdapter)da).Fill(dt);

          break;
      }


      lstUsers.DataContext = dt;
    }

  }
}
