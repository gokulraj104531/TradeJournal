using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
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

        public string GenerateToken(string username, string password)
        {
            byte[] keyBytes = new byte[32]; // 256 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyBytes);
            }
            var key = new SymmetricSecurityKey(keyBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(
                issuer: "http://localhost:7012",
                audience: "https://localhost:4200",
                claims: new[] { new Claim(username, password) },
                expires: DateTime.UtcNow.AddMinutes(30), // Set token expiration time
                signingCredentials: signingCredentials
            );



            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
        public bool IsTokenValid(string token)
        {
            try
            {
                byte[] keyBytes = new byte[32]; // 256 bits
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(keyBytes);
                }
                var key = new SymmetricSecurityKey((keyBytes));
                var tokenHandler = new JwtSecurityTokenHandler();



                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:7012",
                    ValidAudience = "http://localhost:4200",
                    IssuerSigningKey = key
                }, out var validatedToken);



                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
