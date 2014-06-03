using System.Data;
using System.Data.SqlClient;

public class DataLayer
{
  public static DataSet GetDataSet(string sql, string connectString)
  {
    DataSet ds = new DataSet();
    SqlDataAdapter da = null;

    //  Create Data Adapter
    da = new SqlDataAdapter(sql, connectString);
    da.Fill(ds);

    return ds;
  }
}