using FancyNotes.Shared;

namespace FancyNotes.Client.Services.Contracts
{
    public interface IUserClientService
    {
        Task<User> GetUser(int id);
        Task<User> VerifyUser(string userName, string password);
        Task<bool> CheckUsername(string userName);
        Task<User> CreateUser(User user);
    }
}
