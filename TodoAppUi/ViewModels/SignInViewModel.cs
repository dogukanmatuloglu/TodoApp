using System.ComponentModel.DataAnnotations;

namespace TodoAppUi.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email adresiniz ")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "{0} alanı  en az {2} karakter uzunluğunda olmalıdır..", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
