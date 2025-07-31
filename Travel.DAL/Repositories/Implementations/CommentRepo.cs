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
        public (bool, string?) CreateComment(Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                //put in this user name from Auth. 
                comment.SetCreatedBy("SalmaCreated");
                db.SaveChanges();
                return (true, null);

            }
            catch (Exception ex) { 
                return(false, ex.Message);
            }
        }

        public (bool, string?) DeleteComment(int postId,int userId)
        {
            try
            {
                var comment = db.Comments.Where(a => a.PostId == postId && a.UserId==userId&& !a.IsDeleted).FirstOrDefault();
                if (comment == null)
                    return (false, "error no comment is found to delete ");
                comment.SetDeleted();
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string?) EditComment(Comment comment)
        {
            try
            {
                var comm = db.Comments.FirstOrDefault(a => a.PostId == comment.PostId);
                if (comm == null)
                    return (false, " this comment no found to edit this");
                if (comm.User.UserId == comment.UserId)
                {
                    comm.UpdateText(comment.Text);
                    comm.SetModified("UserNameModified");
                    db.SaveChanges();
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

        public List<Comment> GetAllComments()
        {
            try
            {
                var comments = db.Comments.Where(a => a.IsDeleted == false).ToList();
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
