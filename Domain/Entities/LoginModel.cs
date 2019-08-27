using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must Enter user name")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must Enter Password")]
        public string Password { get; set; }
    }
}
