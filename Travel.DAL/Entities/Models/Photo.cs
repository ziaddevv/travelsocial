using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.DAL.Entities.Models
{
    public class Photo
    {
        public string URL { get; private set; }
        [ForeignKey("Post")]
        public int PostId { get; private set; }
        public Post Post { get; private set; }
        public Photo(string url, int postId)
        {
            URL = url;
            PostId = postId;
        }

    }
}
