using System.ComponentModel.DataAnnotations;

namespace WebGUI.Areas.Admin.Models
{
    public class ContactModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add the Fax")]
        public string Fax { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add the Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "You have entered an invalidet Email. You should enter a valid one.")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add the address")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add the Phone")]
        [RegularExpression(@"(01)(0|1|2|5)[0-9]{8}", ErrorMessage = "It is not a correct phone")]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add the Location")]
        public string GoogleMapLink { get; set; }
    }
}