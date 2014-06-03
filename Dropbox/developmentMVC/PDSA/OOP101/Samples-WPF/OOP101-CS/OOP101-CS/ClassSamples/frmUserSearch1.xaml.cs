using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmUserSearch1.xaml
  /// </summary>
  public partial class frmUserSearch1 : Window
  {
    public frmUserSearch1()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      UserLoad();
    }

    private void UserLoad()
    {
      DataTable dt = new DataTable();
      SqlDataAdapter da = null;

      da = new SqlDataAdapter("SELECT * FROM oopUsers", 
           @"Server=Localhost;Database=Sandbox;Integrated Security=Yes");
      da.Fill(dt);

      lstUsers.DataContext = dt;
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
      UserSearch();
    }

    private void UserSearch()
    {
      string sql = string.Empty;
      string where = " WHERE ";
      DataTable dt = new DataTable();
      SqlDataAdapter da = null;

      if (txtSearchFirstName.Text.Trim() != string.Empty)
      {
        sql += where + " FirstName LIKE '" + txtSearchFirstName.Text + "%'";
        where = " AND ";
      }
      if (txtSearchLastName.Text.Trim() != string.Empty)
      {
        sql += where + " LastName LIKE '" + txtSearchLastName.Text + "%'";
        where = " AND ";
      }
      if (txtSearchEmail.Text.Trim() != string.Empty)
      {
        sql += where + " Email LIKE '%" + txtSearchEmail.Text + "%'";
        where = " AND ";
      }

      da = new SqlDataAdapter("SELECT * FROM oopUsers " + sql, 
            @"Server=Localhost;Database=Sandbox;Integrated Security=Yes");
      da.Fill(dt);

      lstUsers.DataContext = dt;
    }
  }
}
