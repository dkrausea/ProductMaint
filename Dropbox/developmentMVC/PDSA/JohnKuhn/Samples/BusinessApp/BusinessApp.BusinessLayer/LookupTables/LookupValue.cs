using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.BusinessLayer.LookupTables
{
   public class LookupValue
   {
      public int PrimaryKey { get; set; }
      public string CodeValue { get; set; }
      public string DisplayValue { get; set; }
      public string ValueDescription { get; set; }
      public int DisplayOrder { get; set; }
      public bool IsActive { get; set; }
      public string InsertName { get; set; }
      public DateTime InsertDate { get; set; }
      public string UpdateName { get; set; }
      public DateTime UpdateDate { get; set; }
      public short ConcurrencyValue { get; set; }
      public object TableName { get; set; }
   }
}
