using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessApp.Framework.DataAccess;

namespace BusinessApp.BusinessLayer.LookupTables
{
   internal class LookupTableData
   {
      #region Insert

      public void Insert(LookupValue value)
      {
         IDbConnection connection = null;
         IDataParameter param = null;
         IDbCommand command = null;

         try
         {
            connection = DataLayer.CreateConnection(BusinessApp.Configuration.Settings.ConnectionString);
            connection.Open();

            command = DataLayer.CreateCommand("LookupValue_Insert");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            param = DataLayer.CreateParameter("@LookupTable", DbType.String, false);
            param.Value = value.TableName;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@CodeValue", DbType.String, false);
            param.Value = value.CodeValue;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@DisplayValue", DbType.String, false);
            param.Value = value.DisplayValue;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@DisplayOrder", DbType.Int32, false);
            param.Value = value.DisplayOrder;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@ValueDescription", DbType.String, false);
            param.Value = value.ValueDescription;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@IsActive", DbType.Boolean, false);
            param.Value = value.IsActive;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@InsertName", DbType.String, false);
            param.Value = value.InsertName;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@InsertDate", DbType.DateTime, false);
            param.Value = value.InsertDate;
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
         }
         finally
         {
            if (connection != null)
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
         }
      }

      #endregion

      #region Delete

      public void Delete(string tableName, int id)
      {
         IDbConnection connection = null;
         IDataParameter param = null;
         IDbCommand command = null;

         try
         {
            connection = DataLayer.CreateConnection(BusinessApp.Configuration.Settings.ConnectionString);
            connection.Open();

            command = DataLayer.CreateCommand("LookupValue_Delete");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            param = DataLayer.CreateParameter("@LookupTable", DbType.String, false);
            param.Value = tableName;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@PrimaryKey", DbType.Int32, false);
            param.Value = id;
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
         }
         finally
         {
            if (connection != null)
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
         }
      }

      #endregion

      #region Update

      public void Update(LookupValue value)
      {
         IDbConnection connection = null;
         IDataParameter param = null;
         IDbCommand command = null;

         try
         {
            connection = DataLayer.CreateConnection(BusinessApp.Configuration.Settings.ConnectionString);
            connection.Open();

            command = DataLayer.CreateCommand("LookupValue_Update");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            param = DataLayer.CreateParameter("@LookupTable", DbType.String, false);
            param.Value = value.TableName;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@PrimaryKey", DbType.Int32, false);
            param.Value = value.PrimaryKey;
            command.Parameters.Add(param);
            
            param = DataLayer.CreateParameter("@CodeValue", DbType.String, false);
            param.Value = value.CodeValue;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@DisplayValue", DbType.String, false);
            param.Value = value.DisplayValue;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@DisplayOrder", DbType.Int32, false);
            param.Value = value.DisplayOrder;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@ValueDescription", DbType.String, false);
            param.Value = value.ValueDescription;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@IsActive", DbType.Boolean, false);
            param.Value = value.IsActive;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@UpdateName", DbType.String, false);
            param.Value = value.InsertName;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@UpdateDate", DbType.DateTime, false);
            param.Value = value.InsertDate;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@ConcurrencyValue", DbType.Int16, false);
            param.Value = value.ConcurrencyValue;
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
         }
         finally
         {
            if (connection != null)
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
         }
      }

      #endregion

      #region Select

      public LookupValue Select(string tableName, int id)
      {
         LookupValue result = new LookupValue();

         IDataReader reader = null;
         IDbConnection connection = null;
         IDataParameter param = null;
         IDbCommand command = null;

         try
         {
            connection = DataLayer.CreateConnection(BusinessApp.Configuration.Settings.ConnectionString);
            connection.Open();

            command = DataLayer.CreateCommand("LookupValue_Select");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            param = DataLayer.CreateParameter("@LookupTable", DbType.String, false);
            param.Value = tableName;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@PrimaryKey", DbType.Int32, false);
            param.Value = id;
            command.Parameters.Add(param);

            reader = command.ExecuteReader();
            while (reader.Read())
            {
               result.CodeValue = reader["CodeValue"].ToString();
               result.ConcurrencyValue = Convert.ToInt16(reader["ConcurrencyValue"]);
               result.DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]);
               result.DisplayValue = reader["DisplayValue"].ToString();
               result.IsActive = Convert.ToBoolean(reader["IsActive"]);
               result.PrimaryKey = Convert.ToInt32(reader["PrimaryKey"]);
               result.TableName = tableName;
               result.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
               result.UpdateName = reader["UpdateName"].ToString();
               result.ValueDescription = reader["ValueDescription"].ToString();
            }
         }
         finally
         {
            if (connection != null)
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
         }

         return result;
      }

      #endregion

      #region Select table list

      public KeyValuePairCollection SelectTables()
      {
         KeyValuePairCollection result = new KeyValuePairCollection();
         DataSet tables = DataLayer.GetDataSet("SELECT TableName, DisplayName FROM LookupTable", 
            BusinessApp.Configuration.Settings.ConnectionString);
         foreach (DataRow item in tables.Tables[0].Rows)
         {
            result.Add(new KeyValuePair { Key = item["TableName"].ToString(), Value = item["DisplayName"].ToString() });
         }
         
         return result;
      }

      #endregion

      #region Get DataSet

      internal DataSet GetDataSet(string tableName)
      {
         DataSet result = null;
         IDbConnection connection = null;
         IDataParameter param = null;
         IDbCommand command = null;
         IDbDataAdapter adapter = null;

         try
         {
            connection = DataLayer.CreateConnection(BusinessApp.Configuration.Settings.ConnectionString);
            connection.Open();

            command = DataLayer.CreateCommand("LookupValue_SelectAll");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            param = DataLayer.CreateParameter("@LookupTable", DbType.String, false);
            param.Value = tableName;
            command.Parameters.Add(param);

            adapter = DataLayer.CreateDataAdapter(command);
            result = new DataSet("LookupValues");
            adapter.Fill(result);
         }
         finally
         {
            if (connection != null)
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
         }
         
         return result;
      }

      #endregion

      #region Get lookup values

      internal KeyValuePairCollection SelectValues(string tableName, int? id)
      {
         KeyValuePairCollection result = new KeyValuePairCollection();

         IDataReader reader = null;
         IDbConnection connection = null;
         IDataParameter param = null;
         IDbCommand command = null;

         try
         {
            connection = DataLayer.CreateConnection(BusinessApp.Configuration.Settings.ConnectionString);
            connection.Open();

            command = DataLayer.CreateCommand("LookupValue_SelectList");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            param = DataLayer.CreateParameter("@LookupTable", DbType.String, false);
            param.Value = tableName;
            command.Parameters.Add(param);

            param = DataLayer.CreateParameter("@SelectedValue", DbType.Int32, true);
            if (id.HasValue)
            {
               param.Value = id;
            }
            else
            {
               param.Value = DBNull.Value;
            }
            command.Parameters.Add(param);

            reader = command.ExecuteReader();
            result = new KeyValuePairCollection();
            while (reader.Read())
            {
               result.Add(new KeyValuePair { Key = reader["PrimaryKey"].ToString(), Value = reader["DisplayValue"].ToString() });
            }
         }
         finally
         {
            if (connection != null)
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
         }

         return result;
      }

      #endregion
   }
}
