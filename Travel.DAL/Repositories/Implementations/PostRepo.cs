using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class PostRepo : IPostRepo
    {
        private readonly TravelStateDbContext db;
        public PostRepo(TravelStateDbContext db)
        {
            this.db = db;
        }
        public (bool, string?) CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public (bool, string?) DeletePost(int id)
        {
            try
            {
                var post = db.posts.Where(a => a.PostId == id).FirstOrDefault();
                if (post == null)
                    return (false, "error no found ");
                post.DeletePost();
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string?) EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            try
            {
                var posts = db.posts.Where(a => a.IsDeleted == false).ToList();
                return posts;
            }
            catch (Exception ex) { throw; }
        }

        public Post? GetByIdPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
