using System.Windows;


namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmUserSearch3.xaml
  /// </summary>
  public partial class frmUserSearch3 : Window
  {
    public frmUserSearch3()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      UserLoad();
    }

    private void UserLoad()
    {
      Users bo = new Users();

      lstUsers.DataContext = bo.GetAllUsers();
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
      UserSearch();
    }

    private void UserSearch()
    {
      Users bo = new Users();
      UsersSearch srch;

      srch = ucCriteria.GetInfo();

      lstUsers.DataContext = bo.GetUsersByFilter(srch);
     // lstUsers.DataContext = bo.GetUserCollectionByFilter(srch);
    }    
  }
}
