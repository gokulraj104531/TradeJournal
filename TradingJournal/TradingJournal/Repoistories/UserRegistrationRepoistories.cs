using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TradingJournal.Data;
using TradingJournal.Models;
using TradingJournal.Repoistories.Interfaces;

namespace TradingJournal.Repoistories
{
    public class UserRegistrationRepoistories : GenericRepository<UserRegistration>, IUserRegistrationRepoistories
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRegistrationRepoistories(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public void AddUser(UserRegistration user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _dbContext.userRegistrations.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteUser(string username)
        {
            try
            {
                UserRegistration userRegistration = _dbContext.userRegistrations.Find(username);
                if (userRegistration != null)
                {
                    _dbContext.Remove(userRegistration);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public UserRegistration? Login(string username, string password)
        {
            try
            {
                UserRegistration userRegistration = _dbContext.userRegistrations.Find(username);
                if (userRegistration != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, userRegistration.Password))
                    {
                        return userRegistration;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }




        public UserRegistration? GetUserByName(LoginModel loginModel)
        {
            try
            {
                UserRegistration userRegistration = _dbContext.userRegistrations.FirstOrDefault(x => x.UserName == loginModel.UserName);
                if (userRegistration != null)
                {
                    if (userRegistration.Password == loginModel.Password)
                    { return userRegistration; }
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

