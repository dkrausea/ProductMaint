using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootstrapExercise.Models
{
   public class Gun
   {
      public int GunID { get; set; }
      public string SerialNumber { get; set; }
      public string Make { get; set; }
      public string Model { get; set; }
      public string Caliber { get; set; }
      public string Type { get; set; }
   }
}