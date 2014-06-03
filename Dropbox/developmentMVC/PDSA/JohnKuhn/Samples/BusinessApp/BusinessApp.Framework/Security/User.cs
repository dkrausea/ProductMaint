using System.Collections.Generic;

namespace BusinessApp.Framework.Security
{
   public class User
   {
      public string LoginName { get; set; }
      public string Password { get; set; }
      public string UserName { get; set; }
      public List<string> Roles { get; set; }
   }
}
