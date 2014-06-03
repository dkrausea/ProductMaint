using Mvc.Mailer;

namespace MvcChipRequest.Mailers
{ 
    public interface IReportMailer
    {
			MvcMailMessage ReportProduced();
			MvcMailMessage ReportSent();
			MvcMailMessage ReportLoading();
	}
}