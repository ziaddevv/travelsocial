using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IPhotoRepo
    {
        //what the crud must in photo
        (bool, string?) Create(Photo photo);
        Photo? GetById(int id);
        List<Photo> GetAll();
        (bool, string?) Delete(int id);
        (bool, string?) Update(Photo photo);
    }
}
