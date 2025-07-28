using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.DAL.Entities.Models
{
    public class Comment
    {
        [ForeignKey("User")]
        public int UserId { get; private set; }
        public User User { get; private set; }
        [ForeignKey("Post")]
        public int PostId { get; private set; }
        public Post Post { get; private set; }

        public DateTime Time { get; private set; }

        public string Text { get; private set; }
        public Comment(int userId, int postId, string text)
        {
            UserId = userId;
            PostId = postId;
            Text = text;
            Time = DateTime.Now;
        }
    }
}
