using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface ILikeRepo
    {
        Task<(bool, string?)> CreateLike(Like like);
        Task<List<Like>> GetAllLikes();
        Task<(bool, string?)> DeleteLike(int postId, int userId);


    }
}
