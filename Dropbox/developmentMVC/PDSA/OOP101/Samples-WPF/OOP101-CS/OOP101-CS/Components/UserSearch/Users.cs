using System.Data;
using System.Collections.Generic;

public class User
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }
}

public class Users
{
  public DataTable GetAllUsers()
  {
    DataTable dt = null;

    dt = DataLayer.GetDataTable("SELECT * FROM oopUsers",
      AppConfig.ConnectString);

    return dt;
  }

  public DataTable GetUsersByFilter(UsersSearch userSearch)
  {
    string sql = string.Empty;
    string where = " WHERE ";
    DataTable dt = null;

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

    dt = DataLayer.GetDataTable("SELECT * FROM oopUsers " + sql, 
      AppConfig.ConnectString);

    return dt;
  }

  public List<User> GetUserCollectionByFilter(UsersSearch userSearch)
  {
    string sql = string.Empty;
    string where = " WHERE ";
    DataTable dt = null;
    List<User> ret = new List<User>();

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

    dt = DataLayer.GetDataTable("SELECT * FROM oopUsers " + sql,
      AppConfig.ConnectString);

    foreach (DataRow dr in dt.Rows)
    {
      User usr = new User();

      usr.FirstName = dr["FirstName"].ToString();
      usr.LastName = dr["LastName"].ToString();
      usr.Email = dr["Email"].ToString();

      ret.Add(usr);
    }

    return ret;
  }
}