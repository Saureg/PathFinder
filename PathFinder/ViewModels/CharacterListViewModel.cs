using System.Collections.Generic;
using PathFinder.Data.Models;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.ViewModels
{
    public class CharacterListViewModel
    {
        public IEnumerable<Character> Characters { get; set; }

        public IEnumerable<Race> Races { get; set; }

        public IEnumerable<CharClass> CharClasses { get; set; }
        
        public IEnumerable<Data.Models.Users.User> Users { get; set; }
    }
}