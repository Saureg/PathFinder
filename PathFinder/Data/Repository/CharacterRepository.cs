using System.Collections.Generic;
using System.Linq;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;

namespace PathFinder.Data.Repository
{
    public class CharacterRepository : ICharacter
    {
        private readonly AppDbContext _appDbContext;
        
        public CharacterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateCharacter(Character character)
        {
            _appDbContext.Characters.Add(character);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Character> Characters => _appDbContext.Characters;

        public Character GetCharacter(int characterId) =>
            _appDbContext.Characters.FirstOrDefault(r => r.Id == characterId);
    }
}