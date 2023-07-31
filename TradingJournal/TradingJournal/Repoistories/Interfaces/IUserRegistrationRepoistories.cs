using TradingJournal.Models;

namespace TradingJournal.Repoistories.Interfaces
{
    public interface IUserRegistrationRepoistories:IGenericRepository<UserRegistration>
    {
        void AddUser(UserRegistration user);

        //void UpdateUser(UserRegistration user);

        void DeleteUser(string username);

        //List<UserRegistration> GetUsers();

        UserRegistration Login(string username, string password);
        UserRegistration GetUserByName(LoginModel loginModel);
        
    }
}
