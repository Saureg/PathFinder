using System.Collections.Generic;
using PathFinder.Data.Models;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.ViewModels
{
    public class CharacterCreateViewModel
    {
        public Character Character { get; set; }

        public List<CharClass> CharClasses { get; set; }
        
        public List<Race> Races { get; set; }
    }
}
