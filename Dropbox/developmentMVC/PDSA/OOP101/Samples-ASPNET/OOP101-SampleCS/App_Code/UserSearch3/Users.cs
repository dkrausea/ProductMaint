using System.Data;

public class Users
{
  public DataSet GetAllUsers()
  {
    DataSet ds = null;

    ds = DataLayer.GetDataSet("SELECT * FROM oopUsers", AppConfig.ConnectString);

    return ds;
  }

  public DataSet GetUsersByFilter(UsersSearch userSearch)
  {
    string sql = string.Empty;
    string where = " WHERE ";
    DataSet ds = null;

    if (userSearch.FirstName.Trim() != string.Empty)
    {
      sql += where + " FirstName LIKE '" + userSearch.FirstName + "%'";
      where = " AND ";
    }
    if (userSearch.LastName.Trim() != string.Empty)
    {
      sql += where + " LastName LIKE '" + userSearch.LastName + "%'";
      where = " AND ";
    }
    if (userSearch.Email.Trim() != string.Empty)
    {
      sql += where + " Email LIKE '%" + userSearch.Email + "%'";
      where = " AND ";
    }

    ds = DataLayer.GetDataSet("SELECT * FROM oopUsers " + sql, AppConfig.ConnectString);

    return ds;
  }
}