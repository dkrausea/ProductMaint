using System;
using System.Data;

namespace BusinessApp.BusinessLayer.LookupTables
{
   public class LookupTableManager
   {
      public void Add(ILookupValueEntry entry)
      {
         entry.CodeValue = string.Empty;
         entry.ConcurrencyValue = 0;
         entry.DisplayOrder = string.Empty;
         entry.DisplayValue = string.Empty;
         entry.IsActive = true;
         entry.ValueDescription = string.Empty;
         entry.PrimaryKey = -1;
      }

      public void Edit(ILookupValueEntry entry)
      {
         LookupValue value = this.Select(entry.TableName, entry.PrimaryKey);
         entry.CodeValue = value.CodeValue;
         entry.ConcurrencyValue = value.ConcurrencyValue;
         entry.DisplayOrder = value.DisplayOrder.ToString();
         entry.DisplayValue = value.DisplayValue;
         entry.IsActive = value.IsActive;
         entry.ValueDescription = value.ValueDescription;
      }

      public void Save(LookupValue value)
      {
         LookupTableData data = new LookupTableData();
         if (value.PrimaryKey > 0)
         {
            data.Update(value);
         }
         else
         {
            data.Insert(value);
         }
      }

      public void Delete(string tableName, int id)
      {
         LookupTableData data = new LookupTableData();
         data.Delete(tableName, id);
      }

      public LookupValue Select(string tableName, int id)
      {
         LookupTableData data = new LookupTableData();
         LookupValue result = data.Select(tableName, id);
         return result;
      }

      public KeyValuePairCollection SelectTables()
      {
         LookupTableData data = new LookupTableData();
         KeyValuePairCollection result = data.SelectTables();
         return result;
      }

      public void Save(ILookupValueEntry entry)
      {
         LookupValue value = new LookupValue();

         value.CodeValue = entry.CodeValue;
         value.ConcurrencyValue = entry.ConcurrencyValue;
         value.DisplayOrder = Convert.ToInt32(entry.DisplayOrder);
         value.DisplayValue = entry.DisplayValue;
         value.IsActive = entry.IsActive;
         value.PrimaryKey = entry.PrimaryKey;
         value.TableName = entry.TableName;
         value.ValueDescription = entry.ValueDescription;
         value.InsertDate = DateTime.Now;
         value.InsertName = entry.LoginName;
         value.UpdateDate = DateTime.Now;
         value.UpdateName = entry.LoginName;

         this.Save(value);
      }

      public string TableNameFilter { get; set; }

      public void SetFilters(string tableName)
      {
         this.TableNameFilter = tableName;
      }

      public DataSet GetDataSet()
      {
         DataSet result = null;
         LookupTableData data = new LookupTableData();
         result = data.GetDataSet(this.TableNameFilter);
         return result;
      }

      public KeyValuePairCollection GetTables()
      {
         LookupTableData data = new LookupTableData();
         return data.SelectTables();
      }

      public KeyValuePairCollection GetValues(string tableName, int? id)
      {
         LookupTableData data = new LookupTableData();
         return data.SelectValues(tableName, id);
      }
   }
}
