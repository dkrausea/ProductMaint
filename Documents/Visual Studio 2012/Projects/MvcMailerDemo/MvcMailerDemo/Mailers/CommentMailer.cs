using Mvc.Mailer;

namespace MvcMailerDemo.Mailers
{ 
    public class CommentMailer : MailerBase, ICommentMailer 	
	{
		public CommentMailer()
		{
			MasterName="_Layout";
		}
		
		public virtual MvcMailMessage CommentPosted()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "CommentPosted";
				x.ViewName = "CommentPosted";
				x.To.Add("some-email@example.com");
			});
		}
 
		public virtual MvcMailMessage Liked()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Liked";
				x.ViewName = "Liked";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}