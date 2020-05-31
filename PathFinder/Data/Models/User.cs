using System;
using System.ComponentModel.DataAnnotations;

namespace PathFinder.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Невалидный email")]
        [Required(ErrorMessage = "Email обязательное поле")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Email должен быть не менее 5 символов и не более 30")]
        public string Email { get; set; } 
        
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Имя должно быть не менее 3 символов и не более 30")]
        public string Name { get; set; }
        
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Password { get; set; }
        
        public DateTime Created { get; set; }
    }
}