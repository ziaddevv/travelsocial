using Microsoft.EntityFrameworkCore;
using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationDbContext db;
        public CommentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<(bool, string?)> CreateComment(Comment comment)
        {
            try
            {
                await db.Comments.AddAsync(comment);
                //put in this user name from Auth. 
                 comment.SetCreatedBy("SalmaCreated");
                await db.SaveChangesAsync();
                return (true, null);

            }
            catch (Exception ex) { 
                return(false, ex.Message);
            }
        }

        public async Task<(bool, string?)> DeleteComment(int postId,int userId)
        {
            try
            {
                var comment =await db.Comments.Where(a => a.PostId == postId && a.UserId==userId&& !a.IsDeleted).FirstOrDefaultAsync();
                if (comment == null)
                    return (false, "error no comment is found to delete ");
                comment.SetDeleted();
               await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> EditComment(Comment comment)
        {
            try
            {
                var comm =await db.Comments.FirstOrDefaultAsync(a => a.PostId == comment.PostId);
                if (comm == null)
                    return (false, " this comment no found to edit this");
                if (comm.User.UserId == comment.UserId)
                {
                    comm.UpdateText(comment.Text);
                    comm.SetModified("UserNameModified");
                    await db.SaveChangesAsync();
                    return (true, null);
                }
                else
                    return (false, "this user can't edit in this comment ");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task< List<Comment>> GetAllComments()
        {
            try
            {
                var comments =await db.Comments.Where(a => a.IsDeleted == false).ToListAsync();
                return comments;
            }
            catch (Exception ex) { throw; }
        }

        //public Comment? GetByIdComment(int id)
        //{
        //    try
        //    {
        //        var comment = db.Comments.Where(a => a.PostId == id).FirstOrDefault();
        //        if (comment == null)
        //            return null;
        //        return comment;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
