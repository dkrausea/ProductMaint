using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmMain.xaml
  /// </summary>
  public partial class frmMain : Window
  {
    public frmMain()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      frmUserSearch1 frm = new frmUserSearch1();

      frm.Show();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      frmUserSearch2 frm = new frmUserSearch2();

      frm.Show();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
      frmUserSearch3 frm = new frmUserSearch3();

      frm.Show();
    }

    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
      frmInstanceStatic frm = new frmInstanceStatic();

      frm.Show();
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
      frmEnums frm = new frmEnums();

      frm.Show();
    }

    private void Button_Click_5(object sender, RoutedEventArgs e)
    {
      frmInheritance1 frm = new frmInheritance1();

      frm.Show();
    }

    private void Button_Click_6(object sender, RoutedEventArgs e)
    {
      frmInheritance2 frm = new frmInheritance2();

      frm.Show();
    }

    private void Button_Click_7(object sender, RoutedEventArgs e)
    {
      frmInterface1 frm = new frmInterface1();

      frm.Show();
    }

    private void Button_Click_8(object sender, RoutedEventArgs e)
    {
      frmInterface2 frm = new frmInterface2();

      frm.Show();
    }

    private void Button_Click_9(object sender, RoutedEventArgs e)
    {
      frmOverloading1 frm = new frmOverloading1();

      frm.Show();
    }

    private void Button_Click_10(object sender, RoutedEventArgs e)
    {
      frmOverloading2 frm = new frmOverloading2();

      frm.Show();
    }

    private void Button_Click_11(object sender, RoutedEventArgs e)
    {
      frmEventSample frm = new frmEventSample();

      frm.Show();
    }
  }
}
