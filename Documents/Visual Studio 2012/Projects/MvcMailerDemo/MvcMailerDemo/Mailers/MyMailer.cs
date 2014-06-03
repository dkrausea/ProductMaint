using Mvc.Mailer;

namespace MvcMailerDemo.Mailers
{ 
    public class MyMailer : MailerBase	
	{
		public MyMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Welcome()
		{

            ViewBag.Name = "Don";
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Welcome to the MvcMailer";
				x.ViewName = "Welcome";
				x.To.Add("don.krausea@gmail.com");
			});
		}
 	}
}