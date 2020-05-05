using Microsoft.AspNetCore.Mvc.Rendering;
using PathFinder.Data.Models;

namespace PathFinder.ViewModels
{
    public class CharacterCreateViewModel
    {
        public Character Character { get; set; }
        
        public SelectList RaceSelectList { get; set; }
        
        public SelectList CharClassSelectList { get; set; }
    }
}
