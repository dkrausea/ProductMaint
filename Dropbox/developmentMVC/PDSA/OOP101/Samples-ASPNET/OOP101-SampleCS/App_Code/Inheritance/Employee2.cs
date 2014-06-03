public class Employee2 : Person2
{
  private decimal mSalary;

  public decimal Salary
  {
    get { return mSalary; }
    set { mSalary = value; }
  }

  protected override void CreateFullName()
  {
    base.FullName = base.FirstName + " " + base.LastName;
  }
}