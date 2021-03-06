﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using User = PathFinder.Data.Models.Users.User;

namespace PathFinder.Data.Models
{
    public class Character
    {
        [BindNever] public int Id { get; set; }

        [Display(Name = "Имя персонажа")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Имя персонажа должно быть не менее 3-х символов и не более 30")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }

        [Display(Name = "Раса")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int RaceId { get; set; }

        public virtual Race Race { get; set; }

        [Display(Name = "Класс")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int CharClassId { get; set; }

        public virtual CharClass.CharClass CharClass { get; set; }

        [Display(Name = "Возраст")]
        [Range(16, 500, ErrorMessage = "Возраст должен быть от 16 до 500")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Age { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Gender { get; set; }

        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Str { get; set; }

        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Dex { get; set; }

        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Con { get; set; }

        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Int { get; set; }

        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Wis { get; set; }

        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Cha { get; set; }

        [Range(-2, 6, ErrorMessage = "Значение должно быть в диапазоне от -2 до 6")]
        public int StrMod { get; set; }

        [Range(-2, 6, ErrorMessage = "Значение должно быть в диапазоне от -2 до 6")]
        public int DexMod { get; set; }

        [Range(-2, 6, ErrorMessage = "Значение должно быть в диапазоне от -2 до 6")]
        public int ConMod { get; set; }

        [Range(-2, 6, ErrorMessage = "Значение должно быть в диапазоне от -2 до 6")]
        public int IntMod { get; set; }

        [Range(-2, 6, ErrorMessage = "Значение должно быть в диапазоне от -2 до 6")]
        public int WisMod { get; set; }

        [Range(-2, 6, ErrorMessage = "Значение должно быть в диапазоне от -2 до 6")]
        public int ChaMod { get; set; }
        
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}