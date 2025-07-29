using Travel.DAL.DataBase;
using Travel.DAL.Entities.Models;
using Travel.DAL.Migrations;
using Travel.DAL.Repositories.Abstractions;

namespace Travel.DAL.Repositories.Implementations
{
    public class PhotoRepo : IPhotoRepo
    {
        private readonly TravelStateDbContext db;
        public PhotoRepo(TravelStateDbContext db)
        {
            this.db = db;
        }
        public (bool, string?) CreatePhoto(Photo photo)
        {
            throw new NotImplementedException();
        }

        public (bool, string?) DeletePhoto(int id)
        {
            try
            {
                var photo = db.photo.Where(a => a.PostId == id).FirstOrDefault();
                if (photo == null)
                    return (false, "error no found ");
                photo.DeletePhoto();
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<Photo> GetAllPhotos()
        {
            try
            {
                var photos = db.photo.Where(a => a.IsDeleted == false).ToList();
                return photos;
            }
            catch (Exception ex) { throw; }
        }

        public Photo? GetPhotoById(int id)
        {
            try
            {
                var photo = db.photo.Where(a => a.PostId == id).FirstOrDefault();
                if (photo == null)
                    return null;
                return photo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public (bool, string?) UpdatePhoto(Photo photo)
        {
            try
            {
                var phot = db.photo.FirstOrDefault(a => a.PostId == photo.PostId);
                if (phot== null)
                    return (false, "not found");
                //change after insteadof salma to userName 
                phot.UpdatePhoto(photo.URL, "salma Ramadan ");
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
