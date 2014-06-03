using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmInstanceStatic.xaml
  /// </summary>
  public partial class frmInstanceStatic : Window
  {
    public frmInstanceStatic()
    {
      InitializeComponent();
    }

    private void btnInstance_Click(object sender, RoutedEventArgs e)
    {
      MyCommandInstance cmd1 = new MyCommandInstance();
      MyCommandInstance cmd2 = new MyCommandInstance();

      cmd1.CommandText = "SELECT * FROM Products";
      cmd2.CommandText = "SELECT * FROM Users";

      System.Diagnostics.Debugger.Break();
      //  Look at each CommandText property
    }

    private void btnStatic_Click(object sender, RoutedEventArgs e)
    {
      //  The following does not make sense
      MyCommandStatic cmd1 = new MyCommandStatic();
      MyCommandStatic cmd2 = new MyCommandStatic();
      // cmd1.CommandText = "SELECT * FROM Products" ' Not valid

      MyCommandStatic.CommandText = "SELECT * FROM Products";
      MyCommandStatic.CommandText = "SELECT * FROM Users";

      System.Diagnostics.Debugger.Break();
      //  Look at each CommandText property
    }
  }
}
