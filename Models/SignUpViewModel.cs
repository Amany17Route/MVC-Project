using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name Is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last  Name Is Required")]
        public string LasttName { get; set; }

        [Required(ErrorMessage = "Email Name Is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[W_]).{8,}$",ErrorMessage ="Password Must Be Atleast 8 Characters")]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(Password) , ErrorMessage ="Confirm Password Dosen't Match Password")]
        public string ConfimPassword { get; set; }

        [Required(ErrorMessage = "Is Active Is Required")]
        public bool IsAvctive { get; set; }

    }
}
