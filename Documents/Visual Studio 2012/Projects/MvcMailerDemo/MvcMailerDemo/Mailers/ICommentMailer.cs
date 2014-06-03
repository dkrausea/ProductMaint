using Mvc.Mailer;

namespace MvcMailerDemo.Mailers
{ 
    public interface ICommentMailer
    {
			MvcMailMessage CommentPosted();
			MvcMailMessage Liked();
	}
}