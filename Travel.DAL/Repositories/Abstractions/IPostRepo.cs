using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IPostRepo
    {
        (bool, string?) CreatePost(Post post);
        //not sure must post having getbyidpost &&getallposts
        Post? GetByIdPost(int id);

        List<Post> GetAllPosts();
        (bool, string?) DeletePost(int id);
        (bool, string?) EditPost(Post post);
    }
}
