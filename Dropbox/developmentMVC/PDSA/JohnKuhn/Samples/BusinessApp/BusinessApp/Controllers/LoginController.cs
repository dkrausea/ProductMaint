using System;
using System.Web.Mvc;
using System.Web.Security;
using BusinessApp.Framework.Security;
using BusinessApp.Utilities;
using BusinessApp.ViewModels;

namespace BusinessApp.Controllers
{
   public class LoginController : WebController
   {
      public ActionResult Index()
      {
         ActionResult result = null;

         LoginViewModel viewModel = new LoginViewModel();
         if (this.Request.QueryString["ReturnUrl"] != null)
         {            
            Session["ReturnUrl"] = this.Request.QueryString["ReturnUrl"];
            result = RedirectToAction("Index");
         }
         else if (Session["ReturnUrl"] != null)
         {
            viewModel.ReturnUrl = Session["ReturnUrl"].ToString();
            result = View(viewModel);
         }
         else
         {
            result = View(viewModel);
         }
         
         return result;
      }

      [HttpPost]
      public ActionResult Index(LoginViewModel viewModel)
      {
         ActionResult result = null;

         try
         {
            viewModel.SignIn();
            switch (viewModel.AuthenticationResult)
            {
               case AuthenticationResult.Success:
                  FormsAuthentication.SetAuthCookie(viewModel.LoginName, false);
                  result = Redirect(viewModel.ReturnUrl);
                  break;
               case AuthenticationResult.Failure:
                  this.ModelState.AddModelError("Error", viewModel.MessageText);
                  result = View(viewModel);
                  break;
            }
         }
         catch (Exception ex)
         {
            this.ModelState.AddModelError("Error", ex.Message);
            result = View(viewModel);
         }

         return result;
      }
   }
}
