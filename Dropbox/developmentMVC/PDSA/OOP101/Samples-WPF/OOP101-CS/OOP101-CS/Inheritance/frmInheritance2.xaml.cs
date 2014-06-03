using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmInheritance2.xaml
  /// </summary>
  public partial class frmInheritance2 : MyWindow
  {
    public frmInheritance2()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      lblDesignMode.Text = base.IsInDesignMode().ToString();
    }

    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
      string fileName;

      fileName = base.GetCurrentDirectory() +
                   @"\Dictionaries\" + txtXamlName.Text;

      base.LoadSamplesResource(fileName);
    }

  }
}
