using Mvc.Mailer;

namespace MvcMailer_Example.Mailers
{ 
    public interface IReportMailer
    {
			MvcMailMessage ReportProducer();
			MvcMailMessage ReportSent();
			MvcMailMessage ReportLoading();
	}
}