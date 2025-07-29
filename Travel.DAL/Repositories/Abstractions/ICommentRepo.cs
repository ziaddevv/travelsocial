using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface ICommentRepo
    {
        (bool, string?) CreateComment(Comment comment);
        Comment? GetByIdComment(int id);
        List<Comment> GetAllComments();
        (bool, string?) DeleteComment(int id);
        (bool, string?) EditComment(Comment comment);
    }
}
