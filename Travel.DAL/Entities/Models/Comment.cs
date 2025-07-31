using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.DAL.Entities.Models
{
    public class Comment  : AuditableEntity
    {
		public Comment()
		{
			Replies = new List<Comment>();
		}

		public Comment(int userId, int postId, string text, int? parentCommentId = null)
		{
			UserId = userId;
			PostId = postId;
			Text = text;
			ParentCommentId = parentCommentId;

			Replies = new List<Comment>();
		}

		[Key]
		public int CommentId { get; private set; }

		[ForeignKey("User")]
		public int UserId { get; private set; }

		[ForeignKey("Post")]
		public int PostId { get; private set; }

		[ForeignKey("ParentComment")]
		public int? ParentCommentId { get; private set; }  // here it can be null if we don't need to make replies but incase we need replies it is there

		[Required]
		public string Text { get; private set; }



		public virtual User User { get; private set; }
		public virtual Post Post { get; private set; }
		public virtual Comment? ParentComment { get; private set; } // every comment have a parent , it is null if there is not parent
		public virtual ICollection<Comment> Replies { get; private set; }
		 

		public void UpdateText(string text)
		{
			Text = text;
		}
		//public void DeleteComment()
		//{
		//	SetDeleted();
		//}
	}
}
