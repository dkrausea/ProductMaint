using System;
using System.Data;

namespace BusinessApp.Framework.DataAccess
{
   public class DataLayer
   {
      public static DataSet GetDataSet(string SQL, string ConnectString)
      {
         DataSet ds = new DataSet();
         IDbDataAdapter da;

         da = CreateDataAdapter(SQL, ConnectString);
         da.Fill(ds);

         return ds;
      }

      public static DataTable GetDataTable(string SQL, string ConnectString)
      {
         DataSet ds = new DataSet();
         DataTable dt = null;

         ds = GetDataSet(SQL, ConnectString);

         if (ds.Tables.Count > 0)
            dt = ds.Tables[0];

         return dt;
      }

      public static IDataReader GetDataReader(string SQL, string ConnectString)
      {
         IDataReader dr;
         IDbCommand cmd = null;

         try
         {
            // Create Command with Connection Object
            cmd = CreateCommand(SQL, ConnectString);

            // Create the DataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
         }
         finally
         {
            // If there is an exception, close the connection
            if (cmd.Connection.State != ConnectionState.Closed)
            {
               cmd.Connection.Close();
               cmd.Connection.Dispose();
            }

            // Dispose of the Command
            cmd.Dispose();
         }

         return dr;
      }

      public static Object ExecuteScalar(string SQL, string ConnectString)
      {
         IDbCommand cmd = null;
         Object value = null;

         try
         {
            // Create Command with Connection Object
            cmd = CreateCommand(SQL, ConnectString);

            // Execute SQL
            value = cmd.ExecuteScalar();
         }
         finally
         {
            // Close the connection
            if (cmd.Connection.State == ConnectionState.Open)
               cmd.Connection.Close();

            // Dispose of the Objects
            cmd.Connection.Dispose();
            cmd.Dispose();
         }

         return value;
      }

      public static int ExecuteSQL(IDbCommand cmd, bool DisposeOfCommand)
      {
         int intRows = 0;
         bool boolOpen = false;

         try
         {
            // Open the Connection
            if (cmd.Connection.State != ConnectionState.Open)
            {
               cmd.Connection.Open();
            }
            else
            {
               boolOpen = !DisposeOfCommand;
            }

            // Execute SQL
            intRows = cmd.ExecuteNonQuery();
         }
         finally
         {
            if (!boolOpen)
            {
               // Close the connection
               if (cmd.Connection.State == ConnectionState.Open)
               {
                  cmd.Connection.Close();
               }
               // Dispose of the Objects
               cmd.Connection.Dispose();
            }
            if (DisposeOfCommand)
               cmd.Dispose();
         }

         return intRows;
      }

      public static int ExecuteSQL(IDbCommand cmd)
      {
         return ExecuteSQL(cmd, false);
      }

      public static int ExecuteSQL(string SQL, string ConnectString)
      {

         IDbCommand cmd = null;
         int intRows;

         cmd = CreateCommand(SQL, ConnectString);

         // Execute SQL
         intRows = ExecuteSQL(cmd, true);

         return intRows;
      }

      public static IDbConnection CreateConnection(string ConnectString)
      {
         IDbConnection cnn;

         cnn = DataProvider.CreateConnection();
         cnn.ConnectionString = ConnectString;

         return cnn;
      }

      public static IDbCommand CreateCommand(string SQL)
      {
         IDbCommand cmd;

         cmd = DataProvider.CreateCommand();
         cmd.CommandText = SQL;

         return cmd;
      }

      public static IDbCommand CreateCommand(string SQL, string ConnectString)
      {
         return CreateCommand(SQL, ConnectString, true);
      }

      public static IDbCommand CreateCommand(string SQL, string ConnectString, bool OpenConnection)
      {
         IDbCommand cmd;

         cmd = CreateCommand(SQL);
         cmd.Connection = CreateConnection(ConnectString);
         if (OpenConnection)
         {
            cmd.Connection.Open();
         }

         return cmd;
      }

      public static IDataParameter CreateParameter(string ParameterName, DbType DataType, bool nullable)
      {
         IDataParameter param;

         param = DataProvider.CreateParameter(nullable);
         param.DbType = DataType;
         param.ParameterName = ParameterName;

         return param;
      }

      public static IDbDataAdapter CreateDataAdapter(string SQL, string ConnectString)
      {
         IDbDataAdapter da;

         da = DataProvider.CreateDataAdapter();
         da.SelectCommand = CreateCommand(SQL, ConnectString, false);

         return da;
      }

      public static IDbDataAdapter CreateDataAdapter(IDbCommand command)
      {
         IDbDataAdapter da;

         da = DataProvider.CreateDataAdapter();
         da.SelectCommand = command;

         return da;
      }
   }
}