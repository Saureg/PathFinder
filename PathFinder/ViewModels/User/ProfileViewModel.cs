using System.ComponentModel.DataAnnotations;

namespace PathFinder.ViewModels.User
{
    public class ProfileViewModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Невалидный email")]
        [Required(ErrorMessage = "Email обязательное поле")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Email должен быть не менее 5 символов и не более 30")]
        public string Email { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Имя должно быть не менее 3 символов и не более 30")]
        public string Name { get; set; }

        [Display(Name = "Новый пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Роль")] public string RoleName { get; set; }
    }
}