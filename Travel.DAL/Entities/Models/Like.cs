using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.DAL.Entities.Models
{
    public class Like
    {
		public Like() { }

		public Like(int userId, int postId)
		{
			UserId = userId;
			PostId = postId;
			LikedAt = DateTime.UtcNow;
		}

		[ForeignKey("User")]
		public int UserId { get; private set; }

		[ForeignKey("Post")]
		public int PostId { get; private set; }

		public DateTime LikedAt { get; private set; }
		public bool IsDeleted { get; private set; }

		 
		public virtual User User { get; private set; }
		public virtual Post Post { get; private set; }
		public void DeleteLike()
		{
			IsDeleted = true;
		}
		
	}
}
