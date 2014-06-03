using System.Data.SqlClient;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmOverloading2.xaml
  /// </summary>
  public partial class frmOverloading2 : Window
  {
    public frmOverloading2()
    {
      InitializeComponent();
    }

    protected void btnGetDataTable1_Click(object sender, RoutedEventArgs e)
    {
      GetDataTableSQL();
    }
    protected void btnGetDataTable2_Click(object sender, RoutedEventArgs e)
    {
      GetDataTableCmd();
    }

    private void GetDataTableSQL()
    {
      string sql = null;

      sql = "SELECT * FROM oopUsers";

      lstUsers.DataContext = DataLayer2.GetDataTable(sql, AppConfig.ConnectString);
    }

    private void GetDataTableCmd()
    {
      SqlCommand cmd = null;

      cmd = new SqlCommand("SELECT * FROM oopUsers");
      cmd.Connection = new SqlConnection(AppConfig.ConnectString);
      cmd.Connection.Open();

      lstUsers.DataContext = DataLayer2.GetDataTable(cmd);

      cmd.Connection.Close();
      cmd.Connection.Dispose();
    }
  }
}