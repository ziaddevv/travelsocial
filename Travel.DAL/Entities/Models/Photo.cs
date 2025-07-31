using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.DAL.Entities.Models
{
    public class Photo : AuditableEntity
	{
		public Photo() { }

		public Photo(int postId, string url)
		{
			PostId = postId;
			Url = url;
		}

		public int Id { get; private set; }

		[ForeignKey("Post")]
		public int PostId { get; private set; }

		[Required]
		public string Url { get; private set; }


		// Navigation Properties
		public virtual Post Post { get; private set; }
		 public void UpdatePhoto(string url)
		{
			Url = url;
		}

	}
}
