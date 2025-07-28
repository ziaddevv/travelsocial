using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.DAL.Entities.Models
{
    public class Like
    {
        [ForeignKey("User")]

        public int UserId { get; private set; }
        public User User { get; private set; }

        [ForeignKey("Post")]
        public int PostId { get; private set; }
        public Post Post { get; private set; }
        public Like(int userId, int postId)
        {
            UserId = userId;
            PostId = postId;
        }
    }
}
