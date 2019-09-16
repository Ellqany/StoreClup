﻿using System.ComponentModel.DataAnnotations;

namespace WebGUI.Models
{
    public class Manage
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plese add your Phone")]
        [RegularExpression(@"(01)(0|1|2|5)[0-9]{8}", ErrorMessage = "It is not a correct phone")]
        public string PhoneNumber { get; set; }
        public string Billing { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plese add your Address")]
        public string Address { get; set; }
    }
    public class ChangePassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter your old Password")]
        public string OldPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter new your Password")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).{8,15}$", ErrorMessage = "Password must be at least of 8 character and has number and one special chracter at least")]
        public string NewPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must Confirm the password")]
        [Compare("NewPassword", ErrorMessage = "The password does not match")]
        public string ConfirmPassword { get; set; }
    }
    public class ForgetPassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "You have entered an invalidet Email. You should enter a valid one.")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter new your Password")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).{8,15}$", ErrorMessage = "Password must be at least of 8 character and has number and one special chracter at least")]
        public string NewPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must Confirm the password")]
        [Compare("NewPassword", ErrorMessage = "The password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
