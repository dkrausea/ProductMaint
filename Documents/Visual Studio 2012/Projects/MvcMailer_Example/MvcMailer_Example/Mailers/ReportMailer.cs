using Mvc.Mailer;

namespace MvcMailer_Example.Mailers
{ 
    public class ReportMailer : MailerBase, IReportMailer 	
	{
		public ReportMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage ReportProducer()
		{
			ViewBag.Data = "BlockOne";
			return Populate(x =>
			{
				x.Subject = "ReportProducer";
				x.ViewName = "ReportProducer";
				x.To.Add("some-email@example.com");
			});
		}
 
		public virtual MvcMailMessage ReportSent()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "ReportSent";
				x.ViewName = "ReportSent";
				x.To.Add("some-email@example.com");
			});
		}
 
		public virtual MvcMailMessage ReportLoading()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "ReportLoading";
				x.ViewName = "ReportLoading";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}