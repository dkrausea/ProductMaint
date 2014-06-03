using Mvc.Mailer;

namespace MvcChipRequest.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Welcome()
		{
			ViewBag.Name = "Don Krause";
			return Populate(x =>
			{
				x.Subject = "Welcome Don Krause";
				x.ViewName = "Welcome";
				x.To.Add("dkrause@qti.qualcomm.com");
                x.CC.Add("don.krausea@gmail.com");
			});
		}
 
		public virtual MvcMailMessage PasswordReset()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "PasswordReset";
				x.ViewName = "PasswordReset";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}