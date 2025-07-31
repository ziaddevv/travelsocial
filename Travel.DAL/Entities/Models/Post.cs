using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
    public class Post : AuditableEntity
	{
		public Post()
		{
			Photos = new List<Photo>();
			Comments = new List<Comment>();
			Likes = new List<Like>();
		}

		public Post(int userId, string contentText, PostType postType = PostType.General,
					int? tripId = null, string? location = null, bool isPrivate = false)
		{
			UserId = userId;
			ContentText = contentText;
			PostType = postType;
			TripId = tripId;
			Location = location;
			IsPrivate = isPrivate;
			LikeCount = 0;
			CommentCount = 0;

			Photos = new List<Photo>();
			Comments = new List<Comment>();
			Likes = new List<Like>();
		}

		[Key]
		public int PostId { get; private set; }

		[ForeignKey("User")]
		public int UserId { get; private set; }

		[ForeignKey("Trip")]
		public int? TripId { get; private set; }

		[Required]
		public string ContentText { get; private set; }

		[MaxLength(200)]
		public string? Location { get; private set; }

		public bool IsPrivate { get; private set; }

		public int LikeCount { get; private set; }

		public int CommentCount { get; private set; }


		public PostType PostType { get; private set; }
		 

		public virtual User User { get; private set; }
		public virtual Trip? Trip { get; private set; }
		public virtual ICollection<Photo>? Photos { get; private set; }
		public virtual ICollection<Comment>? Comments { get; private set; }
		public virtual ICollection<Like>? Likes { get; private set; }

		
		public void UpdateContent(string contentText, string? location = null)
		{
			ContentText = contentText;
			Location = location;
		}

		public void IncrementLikeCount() => LikeCount++;
		public void DecrementLikeCount() => LikeCount = Math.Max(0, LikeCount - 1);
		public void IncrementCommentCount() => CommentCount++;
		public void DecrementCommentCount() => CommentCount = Math.Max(0, CommentCount - 1);
	}
}
