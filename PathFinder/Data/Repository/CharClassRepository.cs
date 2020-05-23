using System.Collections.Generic;
using System.Linq;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.Data.Repository
{
    public class CharClassRepository : IAllClasses
    {
        private readonly AppDbContext _appDbContext;

        public CharClassRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<CharClass> CharClasses => _appDbContext.CharClasses;

        public CharClass GetClass(int charClassId) => _appDbContext.CharClasses.FirstOrDefault(r => r.Id == charClassId);
        
        public void EditClass(CharClass charClass)
        {
            var currentClass = _appDbContext.CharClasses.SingleOrDefault(r => r.Id == charClass.Id);
            
            if (currentClass == null)
            {
                return;
            }
            
            _appDbContext.Entry(currentClass).CurrentValues.SetValues(charClass);
   
            _appDbContext.SaveChanges();
        }

        public void CreateClass(CharClass charClass)
        {
            _appDbContext.CharClasses.Add(charClass);
            _appDbContext.SaveChanges();
        }

        public void DeleteClass(int classId)
        {
            var currentClass = _appDbContext.CharClasses.SingleOrDefault(r => r.Id == classId);
            
            if (currentClass == null)
            {
                return;
            }
            
            _appDbContext.CharClasses.Remove(currentClass);

            _appDbContext.SaveChanges();
        }
    }
}