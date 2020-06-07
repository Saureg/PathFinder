using System.Collections.Generic;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.Data.Interfaces
{
    public interface IAllClasses
    {
        IEnumerable<CharClass> CharClasses { get; }

        CharClass GetClass(int classId);

        void EditClass(CharClass charClass);

        void CreateClass(CharClass charClass);

        void DeleteClass(int classId);
    }
}