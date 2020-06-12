using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PathFinder.Data.Models.Users
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
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime Created { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "Роль")] public Role Role { get; set; }
        
        public virtual List<Character> Characters { get; set; }
    }
}