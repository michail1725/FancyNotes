using DbAccess;
using FancyNotes.Shared;
using System.Security.Cryptography.X509Certificates;

namespace FancyNotes.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqUsername(string userName)
        {
            return !_context.Users.Any(x => x.UserName == userName);
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool VerifyLoginData(string userName, string password)
        {
            return !_context.Users.Any(x => x.UserName == userName && x.Password == password);
        }
    }
}
