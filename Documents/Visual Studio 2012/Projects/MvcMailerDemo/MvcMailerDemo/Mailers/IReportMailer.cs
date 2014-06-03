using Mvc.Mailer;

namespace MvcMailerDemo.Mailers
{ 
    public interface IReportMailer
    {
			MvcMailMessage ReportProduced();
			MvcMailMessage ReportSent();
			MvcMailMessage ReportLoading();
	}
}