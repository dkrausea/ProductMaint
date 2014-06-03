using System.Data;
using System.Data.SqlClient;

namespace BusinessApp.Framework.DataAccess
{
   internal class DataProvider
   {
      // The following methods currently only handle SQL Server
      // However, these could be put into a Case statement to choose
      // which data provider to use based on the ConnectionString.
      public static IDbConnection CreateConnection()
      {
         SqlConnection cnn = new SqlConnection();
         return cnn;
      }

      public static IDbCommand CreateCommand()
      {
         SqlCommand cmd = new SqlCommand();
         return cmd;
      }

      public static IDataParameter CreateParameter(bool nullable)
      {
         SqlParameter param = new SqlParameter();
         param.IsNullable = nullable;
         return param;
      }

      public static IDbDataAdapter CreateDataAdapter()
      {
         SqlDataAdapter da = new SqlDataAdapter();
         return da;
      }
   }
}