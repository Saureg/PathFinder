using System.ComponentModel.DataAnnotations;

namespace PathFinder.Data.Models
{
    public class Race
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Название расы должно быть не менее 3-х символов и не более 30")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }

        [Display(Name = "Описание")] public string Description { get; set; }

        public string Image { get; set; }

        [Display(Name = "Модификатор силы")]
        [Range(-2, 2, ErrorMessage = "Модификатор должен быть от -2 до 2")]
        public int StrTrait { get; set; }

        [Display(Name = "Модификатор ловкости")]
        [Range(-2, 2, ErrorMessage = "Модификатор должен быть от -2 до 2")]
        public int DexTrait { get; set; }

        [Display(Name = "Модификатор выносливости")]
        [Range(-2, 2, ErrorMessage = "Модификатор должен быть от -2 до 2")]
        public int ConTrait { get; set; }

        [Display(Name = "Модификатор интеллекта")]
        [Range(-2, 2, ErrorMessage = "Модификатор должен быть от -2 до 2")]
        public int IntTrait { get; set; }

        [Display(Name = "Модификатор мудрости")]
        [Range(-2, 2, ErrorMessage = "Модификатор должен быть от -2 до 2")]
        public int WisTrait { get; set; }

        [Display(Name = "Модификатор харизмы")]
        [Range(-2, 2, ErrorMessage = "Модификатор должен быть от -2 до 2")]
        public int ChaTrait { get; set; }

        [Display(Name = "Модификатор любой характеристики")]
        [Range(-2, 2, ErrorMessage = "Модификатор должен быть от -2 до 2")]
        public int AnyTrait { get; set; }
    }
}