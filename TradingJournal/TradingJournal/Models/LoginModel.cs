using System.ComponentModel.DataAnnotations;

namespace TradingJournal.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter Your UserName")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage ="Enter Your Password")]
        public string Password { get; set; }=null!;
    }
}
