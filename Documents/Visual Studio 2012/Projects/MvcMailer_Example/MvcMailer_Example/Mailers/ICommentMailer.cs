using Mvc.Mailer;

namespace MvcMailer_Example.Mailers
{ 
    public interface ICommentMailer
    {
			MvcMailMessage CommentPosted();
			MvcMailMessage Liked();
	}
}