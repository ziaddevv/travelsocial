using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class LikeRepo : ILikeRepo
    {
        private readonly TravelStateDbContext db;
        public LikeRepo(TravelStateDbContext db)
        {
            this.db = db;
        }
        public (bool, string?) CreateLike(Like like)
        {
            try
            {
                db.likes.Add(like);
                db.SaveChanges();
                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string?) DeleteLike(int id)
        {
            try
            {
                var like = db.likes.Where(a => a.PostId == id).FirstOrDefault();
                if (like == null)
                    return (false, "error no found ");
                like.DeleteLike();
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<Like> GetAllLikes()
        {
            throw new NotImplementedException();
        }
    }
}
