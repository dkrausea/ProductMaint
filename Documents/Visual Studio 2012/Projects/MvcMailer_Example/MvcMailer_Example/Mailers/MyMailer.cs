using Mvc.Mailer;

namespace MvcMailer_Example.Mailers
{ 
    public class MyMailer : MailerBase, IMyMailer 	
	{
		public MyMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage Hello()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Hello";
				x.ViewName = "Hello";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}