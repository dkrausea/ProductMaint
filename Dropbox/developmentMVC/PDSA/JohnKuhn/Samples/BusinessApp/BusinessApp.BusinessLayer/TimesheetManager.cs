using System;
using System.Data;
using BusinessApp.Framework.DataAccess;

namespace BusinessApp.BusinessLayer
{
   public class TimesheetManager
   {
      public TimesheetEntry Select(int id)
      {
         TimesheetEntry result = null;

         DataSet ds = DataLayer.GetDataSet(
            string.Format(" SELECT TimesheetEntryId, CustomerId, ProjectId, TaskId, DescriptionValue, Hours FROM dbo.TimesheetEntry WHERE TimesheetEntryId = {0} ", id),
            this.ConnectionString);
         result = this.CreateTimesheetEntry(ds.Tables[0].Rows[0]);

         return result;
      }

      public void Insert(TimesheetEntry entry)
      {
         string sql = string.Format(" INSERT INTO dbo.TimesheetEntry (CustomerId, ProjectId, TaskId, DescriptionValue, Hours) VALUES ({0}, {1}, {2}, '{3}', {4}); SELECT SCOPE_IDENTITY() AS PK ",
            entry.CustomerId, entry.ProjectId, entry.TaskId, entry.Description, entry.Hours);
         int value = Convert.ToInt32(DataLayer.ExecuteScalar(sql, this.ConnectionString));

         this.NewPrimaryKey = value;
      }

      public void Update(TimesheetEntry entry)
      {
         string sql = string.Format(" UPDATE dbo.TimesheetEntry SET CustomerId = {0}, ProjectId = {1}, TaskId = {2}, DescriptionValue = '{3}', Hours = {4} WHERE TimesheetEntryId = {5} ",
            entry.CustomerId, entry.ProjectId, entry.TaskId, entry.Description, entry.Hours, entry.TimesheetEntryId);
         DataLayer.ExecuteSQL(sql, this.ConnectionString);
      }

      public void Delete(int id)
      {
         string sql = string.Format(" DELETE dbo.TimesheetEntry WHERE TimesheetEntry = {0} ", id);
         DataLayer.ExecuteSQL(sql, this.ConnectionString);
      }

      private DataSet GetDataSet()
      {
         return DataLayer.GetDataSet(" SELECT TimesheetEntryId, CustomerId, ProjectId, TaskId, DescriptionValue, Hours FROM dbo.TimesheetEntry ", this.ConnectionString);
      }

      private string ConnectionString
      {
         get { return BusinessApp.Configuration.Settings.ConnectionString; }
      }

      public TimesheetEntryCollection GetTimesheet()
      {
         TimesheetEntryCollection result = new TimesheetEntryCollection();

         DataSet ds = this.GetDataSet();
         DataTable dt = ds.Tables[0];
         foreach (DataRow row in dt.Rows)
         {
            result.Add(this.CreateTimesheetEntry(row));
         }

         return result;
      }

      private TimesheetEntry CreateTimesheetEntry(DataRow row)
      {
         return
            new TimesheetEntry
            {
               TimesheetEntryId = Convert.ToInt32(row["TimesheetEntryId"]),
               CustomerId = Convert.ToInt32(row["CustomerId"]),
               ProjectId = Convert.ToInt32(row["ProjectId"]),
               TaskId = Convert.ToInt32(row["TaskId"]),
               Description = row["DescriptionValue"].ToString(),
               Hours = Convert.ToDouble(row["Hours"])
            };
      }

      public int NewPrimaryKey { get; set; }
   }
}
