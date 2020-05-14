using System.ComponentModel.DataAnnotations;

namespace PathFinder.Data.Models
{
    public class Race
    {
        public int Id { get; set; }
        
        [Display(Name = "Название")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Название расы должно быть не менее 3-х символов и не более 30")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        
        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        public string Image { get; set; }
        
        [Display(Name = "Модификатор силы")]
        [Range(-10, 10, ErrorMessage = "Модификатор должен быть от -10 до 10")]
        public int StrTrait { get; set; }
        
        [Display(Name = "Модификатор ловкости")]
        [Range(-10, 10, ErrorMessage = "Модификатор должен быть от -10 до 10")]
        public int DexTrait { get; set; }
        
        [Display(Name = "Модификатор выносливости")]
        [Range(-10, 10, ErrorMessage = "Модификатор должен быть от -10 до 10")]
        public int ConTrait { get; set; }
        
        [Display(Name = "Модификатор интеллекта")]
        [Range(-10, 10, ErrorMessage = "Модификатор должен быть от -10 до 10")]
        public int IntTrait { get; set; }
        
        [Display(Name = "Модификатор мудрости")]
        [Range(-10, 10, ErrorMessage = "Модификатор должен быть от -10 до 10")]
        public int WisTrait { get; set; }
        
        [Display(Name = "Модификатор харизмы")]
        [Range(-10, 10, ErrorMessage = "Модификатор должен быть от -10 до 10")]
        public int ChaTrait { get; set; }
    }
}