using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class CommentRepo : ICommentRepo
    {
        private readonly TravelStateDbContext db;
        public CommentRepo(TravelStateDbContext db)
        {
            this.db = db;
        }
        public (bool, string?) CreateComment(Comment comment)
        {
            try
            {
                db.comments.Add(comment);
                db.SaveChanges();
                return (true, null);

            }
            catch (Exception ex) { 
                return(false, ex.Message);
            }
        }

        public (bool, string?) DeleteComment(int id)
        {
            try
            {
                var comment = db.comments.Where(a => a.PostId == id).FirstOrDefault();
                if (comment == null)
                    return (false, "error no found ");
                comment.DeleteComment();
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
                var comm = db.comments.FirstOrDefault(a => a.PostId == comment.PostId);
                if (comm == null)
                    return (false, " not found");
                //change after insteadof salma to userName 
                comm.UpdateComment(comment.Text,"salma Ramadan " );
                db.SaveChanges();
                return (true, null);
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
                var comments = db.comments.Where(a => a.IsDeleted == false).ToList();
                return comments;
            }
            catch (Exception ex) { throw; }
        }

        public Comment? GetByIdComment(int id)
        {
            try
            {
                var comment = db.comments.Where(a => a.PostId == id).FirstOrDefault();
                if (comment == null)
                    return null;
                return comment;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
