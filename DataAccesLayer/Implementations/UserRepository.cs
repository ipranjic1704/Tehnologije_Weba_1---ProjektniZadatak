using DataAccessLayer.Model;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly EsportManagerContext context;

        public UserRepository(EsportManagerContext context)
        {
            this.context = context;
        }

        public User Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User? GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(u =>  u.Username == username);
        }

        public bool UsernameExists(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }
    }
}
