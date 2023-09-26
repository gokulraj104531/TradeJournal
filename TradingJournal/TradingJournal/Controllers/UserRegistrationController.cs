using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Services;
using TradingJournal.Services.Interfaces;

namespace TradingJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService _services;

        public UserRegistrationController(IUserRegistrationService services)
        {
            this._services = services;
        }

        //[HttpGet]
        //[Route("Login/{User}/{Pass}")]
        //public string? Login(string User,string Pass) { 
        //    try
        //    {
        //        var validuser= _services.LoginServices(User, Pass);
        //        if(validuser != null)
        //        {
        //            var result = _services.GenerateToken(User);
        //            return result;
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPost("Authenticate")]
        //public IActionResult Authenticate(string User,string Pass)
        //{
        //    if (_services.LoginServices(User,Pass) != null) {

        //      var result = _services.GenerateToken(User);
        //        return Ok(result);
        //    }
        //    else{
        //        return StatusCode(400, "UnAuthenticated user!");
        //    }
        //}
        [HttpGet]
        [Route("Login/{User}/{Pass}")]
        public string? Login(string User, string Pass)
        {
            try
            {
                var validuser = _services.LoginServices(User, Pass);
                if (validuser != null)
                {
                    var result = _services.GenerateToken(User);
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate(string User, string Pass)
        {
            if (_services.LoginServices(User, Pass) != null)
            {

                var result = _services.GenerateToken(User);
                return Ok(result);
            }
            else
            {
                return StatusCode(400, "UnAuthenticated user!");
            }
        }



        [HttpPost]
        [Route("AddUser")]
        public void AddUser(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                _services.AddServices(userRegistrationDTO);
               
            }
            catch (Exception)
            {
                throw; 
            }   
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<UserRegistrationDTO> GetUsers() {
            try
            {
                return _services.GetServices();
            }
            catch (Exception )
            {
                throw;
                

            }
        }

        [HttpPut]
        [Route("EditUser")]
        public IActionResult Edit(UserRegistrationDTO userRegistrationDTO)
        {
            try
            {
                _services.UpdateServices(userRegistrationDTO);
                return StatusCode(200, userRegistrationDTO);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{Username}")]
        public void DeleteUser(string Username)
        {
            try
            {
                _services.DeleteServices(Username);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
