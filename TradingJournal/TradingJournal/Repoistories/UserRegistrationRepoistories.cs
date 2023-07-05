using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TradingJournal.Data;
using TradingJournal.Models;

namespace TradingJournal.Repoistories
{
    public class UserRegistrationRepoistories
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRegistrationRepoistories(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public void AddUser(UserRegistration user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _dbcontext.userRegistrations.Add(user);
                _dbcontext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUser(UserRegistration user)
        {
            try
            {
                _dbcontext.userRegistrations.Update(user);
                _dbcontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                UserRegistration userRegistration = _dbcontext.userRegistrations.Find(id);
                _dbcontext.Remove(userRegistration);
                _dbcontext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserRegistration> GetUsers() {
            try
            {
                List<UserRegistration> users=_dbcontext.userRegistrations.ToList();
                return users;
            }
            catch (Exception)
            {

                throw;
            }    
        }


        public UserRegistration Login(string username, string password)
        {
            try
            {
                UserRegistration userRegistration = _dbcontext.userRegistrations.Find(username);
                if(userRegistration!= null)
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




        public UserRegistration GetUserByName(LoginModel loginModel)
        {
            try
            {
                UserRegistration userRegistration = _dbcontext.userRegistrations.FirstOrDefault(x => x.UserName == loginModel.UserName);
                if(userRegistration != null)
                {
                    if(userRegistration.Password == loginModel.Password)
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

