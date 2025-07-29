using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface ILikeRepo
    {
        (bool, string?) CreateLike(Like like);
        List<Like> GetAllLikes();
        (bool, string?) DeleteLike(int id);
        
    }
}
