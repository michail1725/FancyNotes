using FancyNotes.Shared;


namespace FancyNotes.Service
{
    public interface IUserService : IService
    {
        public Task<User> CreateUser(User user);
        public Task<User> GetUserById(int id);
        public Task<User> UpdateUser(User user);
        public Task DeleteUser(int id);
        public Task<User> VerifyLoginData(string userName, string password);
        public Task<bool> IsUniqUsername (string userName);
        
    }
}
