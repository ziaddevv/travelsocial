using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; private set; }

        public string Caption { get; private set; }
        public PostType PostType { get; private set; }
        public DateTime CreateAt { get; private set; }
        [ForeignKey("User")]
        public int UserId { get; private set; }
        public User User { get; private set; }
        public List<Comment> Comments { get; private set; }
        public List<Like> Likes { get; private set; }
        public List<Photo> Photos { get; private set; }
        public Post(int postId, string caption, PostType postType = PostType.General)
        {
            Caption = caption;
            PostType = postType;
            CreateAt = DateTime.Now;
        }
    }
}
