using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmInterface1.xaml
  /// </summary>
  public partial class frmInterface1 : Window
  {
    public frmInterface1()
    {
      InitializeComponent();
    }

    private void btnTest1_Click(object sender, RoutedEventArgs e)
    {
      Test1();
    }

    private void Test1()
    {
      ITest it = null;

      it = new TestClass1();

      lblMsg.Text = it.InformUser();
    }

    private void btnTest2_Click(object sender, RoutedEventArgs e)
    {
      Test2();
    }

    private void Test2()
    {
      ITest it = null;

      it = new TestClass2();

      lblMsg.Text = it.InformUser();
    }
  }
}
