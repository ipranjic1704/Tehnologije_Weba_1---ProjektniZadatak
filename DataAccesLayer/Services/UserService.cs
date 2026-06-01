using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using DataAccessLayer.Security;

namespace DataAccessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User? Register(string username, string password)
        {
            string trimmedUsername = username.Trim();
            if (repository.UsernameExists(trimmedUsername))
            {
                return null;
            }

            string salt = PasswordHashProvider.GetSalt();
            string hash = PasswordHashProvider.GetHash(password, salt);

            User user = new User
            {
                Username = trimmedUsername,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User"
            };

            return repository.Create(user);
        }

        public User? Login(string username, string password)
        {
            User? existingUser = repository.GetByUsername(username);
            if (existingUser == null)
            {
                return null;
            }

            string hash = PasswordHashProvider.GetHash(password, existingUser.PasswordSalt);
            if (hash != existingUser.PasswordHash)
            {
                return null;
            }

            return existingUser;
        }

        public User? PromoteToAdmin(string username)
        {
            User? user = repository.GetByUsername(username);
            if (user == null)
                return null;
            user.Role = "admin";
            return repository.Update(user);
        }
    }
}