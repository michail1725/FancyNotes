using DbAccess;
using FancyNotes.Shared;
using Microsoft.EntityFrameworkCore;

namespace FancyNotes.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> IsUniqUsername(string userName)
        {
            return Task.FromResult(!_context.Users.Any(x => x.UserName == userName));
        }

        public async Task<User> UpdateUser(User user)
        {
            var updatedUser = _context.Users.Attach(user);
            updatedUser.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> VerifyLoginData(string userName, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName && x.Password == password);
        }

    }
}
