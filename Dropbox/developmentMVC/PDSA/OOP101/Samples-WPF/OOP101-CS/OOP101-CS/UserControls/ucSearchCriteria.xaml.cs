using System.Windows.Controls;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for ucSearchCriteria.xaml
  /// </summary>
  public partial class ucSearchCriteria : UserControl
  {
    public ucSearchCriteria()
    {
      InitializeComponent();
    }

    public UsersSearch GetInfo()
    {
      UsersSearch ret = new UsersSearch();

      ret.Email = txtSearchEmail.Text.Trim();
      ret.FirstName = txtSearchFirstName.Text.Trim();
      ret.LastName = txtSearchLastName.Text.Trim();

      return ret;
    }
  }
}
