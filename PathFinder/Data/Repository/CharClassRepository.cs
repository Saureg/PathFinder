using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Interfaces;
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

        public CharClass GetClass(int classId)
        {
            return _appDbContext.CharClasses
                .Include(x => x.ClassAlignments)
                .FirstOrDefault(r => r.Id == classId);
        }

        public void EditClass(CharClass charClass)
        {
            var currentClass = GetClass(charClass.Id);

            if (currentClass == null) return;

            currentClass.ClassAlignments = charClass.ClassAlignments;

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

            if (currentClass == null) return;

            _appDbContext.CharClasses.Remove(currentClass);

            _appDbContext.SaveChanges();
        }
    }
}