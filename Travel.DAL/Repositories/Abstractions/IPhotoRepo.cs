using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IPhotoRepo
    {
        //what the crud must in photo
        Task<(bool, string?)> AddPhoto(int currentUserId, Photo photo);
        //Photo? GetPhotoById(int id);
        Task<List<Photo>> GetAllPhotos();
        Task<(bool, string?)> DeleteAllPhotos(int postid);
        Task<(bool, string?)> DeleteSeletePhoto(int postId, int photoId);
        Task<(bool, string?)> UpdatePhoto(Photo photo);
    }
}
