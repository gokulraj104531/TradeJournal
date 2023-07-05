using AutoMapper;
using System.Runtime.InteropServices;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Repoistories;

namespace TradingJournal.Services
{
    public class UserRegistrationServices
    {
        private readonly UserRegistrationRepoistories userRegistrationRepoistories;
        private readonly IMapper _mapper;

        public UserRegistrationServices(UserRegistrationRepoistories userRegistrationRepoistories, IMapper mapper)
        {
            this.userRegistrationRepoistories = userRegistrationRepoistories;
            _mapper = mapper;
        }

        public UserRegistrationDTO LoginServices(LoginModel loginModel)
        {
            
            var loginVar = userRegistrationRepoistories.GetUserByName(loginModel);
            var loginModels = _mapper.Map<UserRegistrationDTO>(loginVar);
            return loginModels;

        }

        public void AddServices(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                UserRegistration userRegistration=_mapper.Map<UserRegistration>(userRegistrationDTO);
                userRegistrationRepoistories.AddUser(userRegistration);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateServices(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                UserRegistration userRegistration = _mapper.Map<UserRegistration>(userRegistrationDTO);
                userRegistrationRepoistories.UpdateUser(userRegistration);  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserRegistrationDTO> GetServices()
        {
            try
            {
                var userRegistration = userRegistrationRepoistories.GetUsers();
                List<UserRegistrationDTO> userRegistrationDTOs=_mapper.Map<List<UserRegistrationDTO>>(userRegistration);
                return userRegistrationDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteServices(int id)
        {
            try
            {
                userRegistrationRepoistories.DeleteUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public LoginModel LoginServices(string username,string password)
        {
            try
            {
                var login=userRegistrationRepoistories.Login(username,password);
                LoginModel model=_mapper.Map<LoginModel>(login);
                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //public UserRegistration GetUserName(string userName,string Password)
        //{
        //    try
        //    {
        //        userRegistrationRepoistories.GetUserByName(userName);
        //        return 

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
