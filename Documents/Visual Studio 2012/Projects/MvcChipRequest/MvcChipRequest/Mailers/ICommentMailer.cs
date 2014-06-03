using Mvc.Mailer;

namespace MvcChipRequest.Mailers
{ 
    public interface ICommentMailer
    {
			MvcMailMessage CommentPosted();
			MvcMailMessage Liked();
	}
}