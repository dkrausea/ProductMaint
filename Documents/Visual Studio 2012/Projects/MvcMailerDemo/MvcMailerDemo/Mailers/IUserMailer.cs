using Mvc.Mailer;

namespace MvcMailerDemo.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
			MvcMailMessage PasswordReset();
			MvcMailMessage DriverDelivery();
	}
}