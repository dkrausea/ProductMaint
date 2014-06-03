using System;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmInheritance1.xaml
  /// </summary>
  public partial class frmInheritance1 : Window
  {
    public frmInheritance1()
    {
      InitializeComponent();
    }

    private void btnPerson_Click(object sender, RoutedEventArgs e)
    {
      Person p = new Person();

      p.FirstName = "John";
      p.LastName = "Doe";

      //  Salary is not available
      // p.Salary = Convert.ToDecimal(50000.0)

      lblName.Text = p.LastName + ", " + p.FirstName;
    }

    private void btnEmployee_Click(object sender, RoutedEventArgs e)
    {
      Employee pe = new Employee();

      pe.FirstName = "John";
      pe.LastName = "Doe";
      pe.Salary = Convert.ToDecimal(50000.0);

      lblName.Text = pe.LastName + ", " + pe.FirstName + " - Salary: " + pe.Salary.ToString("c");
    }

    private void btnPerson2_Click(object sender, RoutedEventArgs e)
    {
      Person2 p = new Person2();

      p.FirstName = "John";
      p.LastName = "Doe";

      lblName.Text = p.FullName;
    }

    private void btnEmployee2_Click(object sender, RoutedEventArgs e)
    {
      Employee2 pe = new Employee2();

      pe.FirstName = "John";
      pe.LastName = "Doe";
      pe.Salary = Convert.ToDecimal(50000.0);

      lblName.Text = pe.FullName;
    }
  }
}
