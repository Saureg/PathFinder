using System.Collections.Generic;
using PathFinder.Data.Models;

namespace PathFinder.ViewModels
{
    public class CharacterListViewModel
    {
        public IEnumerable<Character> Characters { get; set; }
        
        public IEnumerable<Race> Races { get; set; }
        
        public IEnumerable<CharClass> CharClasses { get; set; }
    }
}