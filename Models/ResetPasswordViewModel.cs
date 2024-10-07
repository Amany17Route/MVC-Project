using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[W_]).{8,}$", ErrorMessage = "Password Must Be Atleast 8 Characters")]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password Dosen't Match Password")]
        public string ConfimPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
