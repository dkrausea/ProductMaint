public class Employee : Person
{
  private decimal mSalary;

  public decimal Salary
  {
    get { return mSalary; }
    set { mSalary = value; }
  }
}