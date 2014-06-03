using System.Data;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmUserSearch2.xaml
  /// </summary>
  public partial class frmUserSearch2 : Window
  {
    public frmUserSearch2()
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

      dt = DataLayer.GetDataTable("SELECT * FROM oopUsers",
           AppConfig.ConnectString);

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

      dt = DataLayer.GetDataTable("SELECT * FROM oopUsers " + sql, 
            AppConfig.ConnectString);

      lstUsers.DataContext = dt;
    }
  }
}
