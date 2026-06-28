using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.Interface
{
    public interface IUserRepository
    {
        bool UsernameExists(string username);
        User? GetByUsername(string username);
        User Create (User user);
        User Update(User user);
    }
}
