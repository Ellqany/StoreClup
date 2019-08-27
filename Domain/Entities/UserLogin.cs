using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter your First name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter your Last name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "You have entered an invalidet Email. You should enter a valid one.")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter your Password")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).{8,15}$", ErrorMessage = "Password must be at least of 8 character and has number and one special chracter at least")]
        public string Password { get; set; }
    }
}
