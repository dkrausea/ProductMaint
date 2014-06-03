using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Framework.Security
{
   public class SignInResult
   {
      public AuthenticationResult AuthenticationResult { get; set; }
      public string MessageText { get; set; }
   }

   public class SecurityProvider
   {
      private User User { get; set; }

      public SignInResult SignIn(string loginName, string password)
      {
         // Could use a variety of different approaches,
         // for example, the ASP.NET Membership Provider

         // As an example, get the user from a repository
         // and validate the credentials.

         SignInResult result = new SignInResult();

         this.User = this.Retrieve(loginName);

         // Naïve validation of login name and password,
         // for demo use only.
         if (this.User.LoginName == loginName & this.User.Password == password)
         {
            result.AuthenticationResult = AuthenticationResult.Success;
         }
         else
         {
            result.AuthenticationResult = AuthenticationResult.Failure;
            result.MessageText = "Invalid login.";
         }

         return result;
      }

      public User Retrieve(string loginName)
      {
         User result = new User();

         result.LoginName = loginName;
         result.Password = "Pa$$word";
         result.UserName = "dkrause";
         result.Roles = new List<string>();
         result.Roles.Add("Administrator");

         return result;
      }

      public User GetUser(int userId)
      {
         return new User();
      }

      public RoleCollection GetRoles(int userId)
      {
         return new RoleCollection();
      }

      public PermissionCollection GetPermissions(int userId)
      {
         return new PermissionCollection();
      }

      public IPrincipal CreatePrincipal()
      {
         GenericIdentity identity = new GenericIdentity(this.User.LoginName);
         GenericPrincipal result = new GenericPrincipal(identity, this.User.Roles.ToArray());
         return result;
      }
   }

   public class Role
   {
   }

   public class Permission
   {
   }

   public class RoleCollection : List<Role>
   {
   }

   public class PermissionCollection : List<Permission>
   {
   }
}
