using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Migrations;
using Travel.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Travel.DAL.Repositories.Implementations
{
    public class PostRepo : IPostRepo
    {
        private readonly ApplicationDbContext db;
        public PostRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<(bool, string?)> CreatePostAsync(Post post)
        {
           await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();
            return(true, null);
        }

        public async Task< (bool, string?) >DeletePost(int postId)
        {
            try
            {
                var post =await db.Posts
                     .Include(p => p.Comments)
                     .Include(p => p.Likes)
                     .FirstOrDefaultAsync(p => p.PostId == postId);

                if (post == null)
                    return (false, "Post not found.");

                if (post.IsDeleted)
                    return (false, "Post is already deleted.");

                post.SetDeleted(); 
                foreach(var comment in post.Comments.Where(c => !c.IsDeleted))
                {
                    comment.SetDeleted();
                }
                foreach (var like in post.Likes.Where(l => !l.IsDeleted))
                {
                    like.DeleteLike();
                    
                }
               await db.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }


        public async Task< (bool, string?) >EditPost(Post post)
        {
            try
            {
                var postToEdit =await db.Posts.FirstOrDefaultAsync(p => p.PostId == post.PostId);

                if (postToEdit == null)
                    return (false, "Post not found.");

                if (postToEdit.IsDeleted)
                    return (false, "Cannot edit a deleted post.");

                if (postToEdit.UserId != post.UserId)
                    return (false, "You are not authorized to edit this post.");

                postToEdit.UpdateContent(post.ContentText, post.Location);
                await db.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }


        public async Task< List<Post>> GetAllPosts()
        {
            try
            {
                var posts =await db.Posts
                    .Where(p => !p.IsDeleted)
                    .Include(p => p.User)
                    .Include(p => p.Photos)
                    .Include(p => p.Comments.Where(c => !c.IsDeleted))
                    .Include(p => p.Likes.Where(l => !l.IsDeleted))
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting posts: " + ex.Message, ex);
            }
        }


        public async Task< Post?> GetByIdPost(int postId)
        {
            try
            {
                var post =await db.Posts
                             .Include(p => p.User)
                             .Include(p => p.Photos)
                             .Include(p => p.Comments.Where(c => !c.IsDeleted))
                             .Include(p => p.Likes.Where(l => !l.IsDeleted))
                             .FirstOrDefaultAsync(p => p.PostId == postId && !p.IsDeleted);
                return post;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting post with ID {postId}: {ex.Message}", ex);
            }
        }



    }
}
