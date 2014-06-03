using Mvc.Mailer;

namespace MvcMailer_Example.Mailers
{ 
    public interface IMyMailer
    {
			MvcMailMessage Hello();
	}
}