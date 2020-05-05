using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PathFinder.Data.Models
{
    public class Character
    {
        [BindNever]
        public int Id { get; set; }
        
        [Display(Name = "Имя персонажа")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Имя персонажа должно быть не менее 3-х символов и не более 30")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        
        [Display(Name = "Раса")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int RaceId { get; set; }
        
        public virtual Race Race { get; set; }
        
        [Display(Name = "Класс")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int CharClassId { get; set; }
        
        public virtual CharClass CharClass { get; set; } 
        
        [Display(Name = "Возраст")]
        [Range(16, 100, ErrorMessage = "Возраст должен быть от 16 до 100")]
        public int Age { get; set; }
        
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        
        public uint PointBuy { get; set; }
        
        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        public uint Str { get; set; }
        
        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        public uint Dex { get; set; }
        
        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        public uint Con { get; set; }
        
        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        public uint Int { get; set; }
        
        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        public uint Wis { get; set; }
        
        [Range(7, 18, ErrorMessage = "Значение должно быть в диапазоне от 7 до 18")]
        public uint Cha { get; set; }
    }
}