using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Inheritance_InheritanceSample1 : System.Web.UI.Page
{
  protected void btnPerson_Click(object sender, EventArgs e)
  {
    Person p = new Person();

    p.FirstName = "John";
    p.LastName = "Doe";

    //  Salary is not available
    // p.Salary = Convert.ToDecimal(50000.0)
  }

  protected void btnEmployee_Click(object sender, EventArgs e)
  {
    Employee pe = new Employee();

    pe.FirstName = "John";
    pe.LastName = "Doe";
    pe.Salary = Convert.ToDecimal(50000.0);
  }
  
  protected void btnPerson2_Click(object sender, EventArgs e)
  {
    Person2 p = new Person2();

    p.FirstName = "John";
    p.LastName = "Doe";

    lblName.Text = p.FullName;
  }

  protected void btnEmployee2_Click(object sender, EventArgs e)
  {
    Employee2 pe = new Employee2();

    pe.FirstName = "John";
    pe.LastName = "Doe";
    pe.Salary = Convert.ToDecimal(50000.0);

    lblName.Text = pe.FullName;
  }
}
