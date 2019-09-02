using System.ComponentModel.DataAnnotations;

namespace WebGUI.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must Enter user name")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must Enter Password")]
        public string Password { get; set; }
    }
}
