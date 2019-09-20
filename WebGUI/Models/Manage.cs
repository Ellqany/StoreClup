using System.ComponentModel.DataAnnotations;

namespace WebGUI.Models
{
    public class Manage
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plese add your Phone")]
        public string PhoneNumber { get; set; }
        public string Billing { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plese add your Address")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "You have entered an invalidete Email")]
        public string Email { get; set; }
    }
    public class ForgetPassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "You have entered an invalidet Email. You should enter a valid one.")]
        public string Email { get; set; }
    }
}
