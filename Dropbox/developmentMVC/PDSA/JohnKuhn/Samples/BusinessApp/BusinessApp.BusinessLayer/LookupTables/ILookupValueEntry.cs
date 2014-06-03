using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.BusinessLayer.LookupTables
{
   public interface ILookupValueEntry
   {
      int PrimaryKey { get; set; }
      string CodeValue { get; set; }
      string DisplayValue { get; set; }
      string ValueDescription { get; set; }
      string DisplayOrder { get; set; }
      bool IsActive { get; set; }
      string LoginName { get; }
      short ConcurrencyValue { get; set; }
      string TableName { get; set; }
   }
}
