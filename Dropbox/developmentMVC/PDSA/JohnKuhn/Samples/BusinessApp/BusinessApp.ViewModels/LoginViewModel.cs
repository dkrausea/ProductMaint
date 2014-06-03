using BusinessApp.BusinessLayer;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using BusinessApp.Framework.Security;

namespace BusinessApp.ViewModels
{
   public class LoginViewModel
   {
      [Display(Name = "Login Name")]
      [Required(ErrorMessage = "Login name is required")]
      public string LoginName { get; set; }

      [Display(Name = "Password")]
      [Required(ErrorMessage = "Password is required")]
      public string Password { get; set; }

      public string ReturnUrl { get; set; }
      public AuthenticationResult AuthenticationResult { get; set; }
      public bool IsMessageVisible { get; set; }
      public bool IsEditPanelVisible { get; set; }
      public bool IsButtonPanelVisible { get; set; }
      public string MessageText { get; set; }

      public void SignIn()
      {
         SecurityProvider provider = new SecurityProvider();
         SignInResult result = provider.SignIn(this.LoginName, this.Password);
         this.AuthenticationResult = result.AuthenticationResult;
         this.MessageText = result.MessageText;
      }
   }
}
