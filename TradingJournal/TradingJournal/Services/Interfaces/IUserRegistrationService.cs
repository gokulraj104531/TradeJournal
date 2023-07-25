using TradingJournal.DTO;
using TradingJournal.Models;

namespace TradingJournal.Services.Interfaces
{
    public interface IUserRegistrationService
    {
        UserRegistrationDTO LoginServices(LoginModel loginModel);
        void AddServices(UserRegistrationDTO userRegistrationDTO);
        void UpdateServices(UserRegistrationDTO userRegistrationDTO);
        List<UserRegistrationDTO> GetServices();
        void DeleteServices(int id);
        LoginModel LoginServices(string username, string password);
        string GenerateToken(string username);
        bool IsTokenValid(string token);
    }
}
