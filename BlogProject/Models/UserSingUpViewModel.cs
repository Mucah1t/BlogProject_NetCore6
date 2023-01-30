using System.ComponentModel.DataAnnotations;

namespace BlogProjectUI.Models
{
    public class UserSingUpViewModel
    {
        [Display(Name ="Name Surname")]
        [Required(ErrorMessage ="Please enter name and surname.")]
        public string nameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="The passwrods are not same.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Address")]
        [Required(ErrorMessage = "Please enter a mail address")]
        public string mail { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter an username")]
        public string userName { get; set; }
    }
}
