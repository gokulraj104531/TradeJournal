using TradingJournal.Models;

namespace TradingJournal.Repoistories.Interfaces
{
    public interface IUserRegistrationRepoistories:IGenericRepository<UserRegistration>
    {
        void AddUser(UserRegistration user);

        void DeleteUser(string username);
        UserRegistration Login(string username, string password);
        UserRegistration GetUserByName(LoginModel loginModel);
        
    }
}
