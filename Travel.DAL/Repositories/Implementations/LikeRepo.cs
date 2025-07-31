using Microsoft.EntityFrameworkCore;
using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class LikeRepo : ILikeRepo
    {
        private readonly ApplicationDbContext db;
        public LikeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task< (bool, string?)> CreateLike(Like like)
        {
            try
            {
                var existing =await db.Likes
                    .FirstOrDefaultAsync(l => l.PostId == like.PostId && l.UserId == like.UserId);

                if (existing != null)
                {
                    if (existing.IsDeleted)
                    {
                        existing.DeleteLike() ;
                        db.Likes.Update(existing);
                    }
                    else
                    {
                        return (false, "User already liked this post.");
                    }
                }
                else
                {
                    await db.Likes.AddAsync(like);
                }

                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        //edit after auth the userId must be string
        public async Task< (bool, string?)> DeleteLike(int postId,int userId)
        {
            try
            {
                var like =await db.Likes.Where(a => a.PostId == postId && a.UserId==userId&& !a.IsDeleted).FirstOrDefaultAsync();
                if (like == null)
                    return (false, "error no like to delete ");
                like.DeleteLike();
                db.Likes.Update(like);
               await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        

        public async Task< List<Like>> GetAllLikes()
        {
            try
            {
                var likes =await db.Likes.Where(a => a.IsDeleted == false).ToListAsync();
                return likes;
            }
            catch (Exception ex) { return new List<Like>(); }
        }
    }
}
