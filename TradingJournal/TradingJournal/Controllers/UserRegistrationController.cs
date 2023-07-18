using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using TradingJournal.DTO;
using TradingJournal.Models;
using TradingJournal.Services;

namespace TradingJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly UserRegistrationServices _services;

        public UserRegistrationController(UserRegistrationServices services)
        {
            this._services = services;
        }

        [HttpGet]
        [Route("Login/{User}/{Pass}")]
        public string? Login(string User,string Pass) { 
            try
            {
                var validuser= _services.LoginServices(User, Pass);
                if(validuser != null)
                {
                    var result = _services.GenerateToken(User, Pass);
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
        public IActionResult Authenticate(LoginModel login,string User,string Pass)
        {
            if (_services.LoginServices(login) != null) {
                //return StatusCode(200, "Authenticated user!");
              var result = _services.GenerateToken(User, Pass);
                return Ok(result);
            }
            else{
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
               // return StatusCode(200, userRegistrationDTO);
            }
            catch (Exception)
            {
               // return StatusCode(500, ex.Message);
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
                //return NoContent();

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
        [Route("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            try
            {
                _services.DeleteServices(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
