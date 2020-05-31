using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PathFinder.Data.Models.CharClass
{
    public class CharClass
    {
        public int Id { get; set; }
        
        [Display(Name = "Название класса")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Название класса должно быть не менее 3-х символов и не более 30")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }
        
        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Display(Name = "Роль")]
        public string Role { get; set; }
        
        public string Image { get; set; }
        
        [Display(Name = "Доступные мировоззрения")]
        public List<ClassAlignment> ClassAlignments { get; set; }
        
        [Display(Name = "Хиты здоровья")]
        public string HitDice { get; set; }
    }
}