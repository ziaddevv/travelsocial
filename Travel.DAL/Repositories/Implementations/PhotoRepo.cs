using Microsoft.EntityFrameworkCore;
using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Migrations;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class PhotoRepo : IPhotoRepo
    {
        private readonly ApplicationDbContext db;
        public PhotoRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        //update to currentUserId to Auth when applied this
        public async Task< (bool, string?) > AddPhoto(int currentUserId, Photo photo)
        {
            try
            {
                var post =await db.Posts.FirstOrDefaultAsync(p => p.PostId == photo.PostId && !p.IsDeleted);
                if (post == null)
                    return (false, "Post not found.");
                if (post.UserId != currentUserId)
                    return (false, "You are not authorized to add a photo to this post.");
                await db.Photos.AddAsync(photo);
               await db.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }



        public async Task<(bool, string?)> DeleteAllPhotos(int postid)
        {
            try
            {
                var photos =await db.Photos.Where(a => a.PostId == postid).ToListAsync();
                if (!photos.Any())
                    return (false, "error no found ");
                foreach(var photo in photos)
                {
                    photo.SetDeleted();
                }
                
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }


        public async Task< (bool, string?) >DeleteSeletePhoto(int postId, int photoId)
        {
            try
            {
                var photo =await db.Photos
                              .FirstOrDefaultAsync(p => p.PostId == postId && p.Id == photoId && !p.IsDeleted);

                if (photo == null)
                    return (false, "Photo not found.");

                photo.SetDeleted();
                await db.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task< List<Photo>> GetAllPhotos()
        {
            try
            {
                var photos =await db.Photos.Where(a => a.IsDeleted == false).ToListAsync();
                return photos;
            }
            catch (Exception ex) { throw; }
        }

        //public Photo? GetPhotoById(int postid)
        //{
        //    try
        //    {
        //        var photo = db.Photos.Where(a => a.PostId == postid).FirstOrDefault();
        //        if (photo == null)
        //            return null;
        //        return photo;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public async Task<(bool, string?)> UpdatePhoto(Photo photo)
        {
            try
            {
                //to return the info of  post and user who create the photo
                var existingPhoto =await  db.Photos
                      .Include(p => p.Post)
                      .FirstOrDefaultAsync(p => p.Id == photo.Id && !p.IsDeleted);
                if (existingPhoto == null)
                    return (false, "Photo not found");
                if (existingPhoto.Post.UserId == photo.Post.UserId)
                {
                    existingPhoto.UpdatePhoto(photo.Url);  
                    await db.SaveChangesAsync();
                    return (true, null);

                }
                return (false, "this user cannot edit the photo of post");
                
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

    }
}
