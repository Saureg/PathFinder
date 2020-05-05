using System.Collections.Generic;
using PathFinder.Data.Models;

namespace PathFinder.Data.Interfaces
{
    public interface IAllClasses
    {
        IEnumerable<CharClass> CharClasses { get; }
        
        CharClass GetClass(int raceId);
    }
}