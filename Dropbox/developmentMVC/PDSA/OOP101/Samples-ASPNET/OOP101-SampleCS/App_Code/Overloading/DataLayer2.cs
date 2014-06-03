using System.Data;
using System.Data.SqlClient;

public class DataLayer2
{
  public static DataSet GetDataSet(string sql, string connectString)
  {
    SqlCommand cmd = null;
    SqlConnection cnn = null;

    //  Create Command Object
    cmd = new SqlCommand(sql);
    //  Create Connection Object
    cnn = new SqlConnection(connectString);
    //  Assign Connection to Command Object
    cmd.Connection = cnn;

    //  Call Overloaded GetDataSet method
    return GetDataSet(cmd);
  }

  public static DataSet GetDataSet(SqlCommand cmd)
  {
    DataSet ds = new DataSet();
    SqlDataAdapter da = null;

    //  Create Data Adapter
    da = new System.Data.SqlClient.SqlDataAdapter(cmd);
    da.Fill(ds);

    return ds;
  }

  public static int ExecuteSQL(IDbCommand cmd)
  {
    int intRows = 0;

    intRows = cmd.ExecuteNonQuery();

    return intRows;
  }

  public static int ExecuteSQL(string sql, string connectString)
  {
    SqlCommand cmd = null;
    int ret = 0;

    //  Create Command & Connection Objects
    cmd = new SqlCommand(sql);
    cmd.Connection = new SqlConnection(connectString);
    cmd.Connection.Open();

    //  Execute SQL
    ret = ExecuteSQL(cmd);
    cmd.Connection.Close();
    cmd.Connection.Dispose();

    return ret;
  }
}