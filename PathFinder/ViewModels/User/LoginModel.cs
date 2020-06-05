using System.ComponentModel.DataAnnotations;

namespace PathFinder.ViewModels.User
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
         
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}