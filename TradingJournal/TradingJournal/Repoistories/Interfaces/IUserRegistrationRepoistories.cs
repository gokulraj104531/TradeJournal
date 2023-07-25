using TradingJournal.Models;

namespace TradingJournal.Repoistories.Interfaces
{
    public interface IUserRegistrationRepoistories
    {
        void AddUser(UserRegistration user);
        void UpdateUser(UserRegistration user);
        void DeleteUser(int id);
        List<UserRegistration> GetUsers();
        UserRegistration Login(string username, string password);
        UserRegistration GetUserByName(LoginModel loginModel);
    }
}
