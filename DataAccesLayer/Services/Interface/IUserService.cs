using DataAccessLayer.Model;

namespace DataAccessLayer.Services.Interface
{
    public interface IUserService
    {
        User? Register(string username, string password);
        User? Login(string username, string password);
        User? PromoteToAdmin(string username);
    }
}
