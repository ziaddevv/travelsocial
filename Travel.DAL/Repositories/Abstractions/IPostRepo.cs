using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IPostRepo
    {
        Task<(bool, string?)> CreatePostAsync(Post post);
        //not sure must post having getbyidpost &&getallposts
        Task<Post?> GetByIdPost(int postId);

        Task<List<Post>> GetAllPosts();
        Task<(bool, string?)> DeletePost(int postId);
        Task<(bool, string?)> EditPost(Post post);
    }
}
