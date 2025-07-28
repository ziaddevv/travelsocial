using Travel.DAL.Entities.Models;

namespace Travel.DAL.Repositories.Abstractions
{
    public interface IUserRepo
    {
        //i want GetById to find the name of user
        public string GetUserById(int id);

    }
}
