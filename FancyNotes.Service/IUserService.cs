using FancyNotes.Shared;


namespace FancyNotes.Service
{
    public interface IUserService : IService
    {
        public User CreateUser(User user);
        public User GetUserById(int id);
        public User GetUserByName(string userName);
        public User UpdateUser(User user);
        public void DeleteUser(int id);
        public bool VerifyLoginData(string userName, string password);
        public bool IsUniqUsername (string userName);
    }
}
