using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface ICommentRepo
    {
        Task<(bool, string?)> CreateComment(Comment comment);
        //Comment? GetByIdComment(int id);
        Task<List<Comment>> GetAllComments();
        Task<(bool, string?)> DeleteComment(int postId, int userId);
        Task<(bool, string?)> EditComment(Comment comment);
    }
}
