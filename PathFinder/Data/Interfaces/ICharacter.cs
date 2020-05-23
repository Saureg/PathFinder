using System.Collections.Generic;
using PathFinder.Data.Models;

namespace PathFinder.Data.Interfaces
{
    public interface ICharacter
    {
        void CreateCharacter(Character character);
        
        IEnumerable<Character> Characters { get; }
        
        Character GetCharacter(int characterId);

        void DeleteCharacter(int characterId);
    }
}