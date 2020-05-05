using System.Collections.Generic;
using System.Linq;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;

namespace PathFinder.Data.Repository
{
    public class CharClassRepository : IAllClasses
    {
        private readonly AppDbContext _appDbContent;

        public CharClassRepository(AppDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<CharClass> CharClasses => _appDbContent.CharClasses;

        public CharClass GetClass(int charClassId) => _appDbContent.CharClasses.FirstOrDefault(r => r.Id == charClassId);
    }
}