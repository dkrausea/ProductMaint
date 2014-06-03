using Mvc.Mailer;

namespace MvcChipRequest.Mailers
{ 
    public interface IDriverMailer
    {
			MvcMailMessage DeliveryDriver();
	}
}