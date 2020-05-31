using System.Collections.Generic;
using PathFinder.Data.Models.Alignment;

namespace PathFinder.Data.Interfaces
{
    public interface IAllAlignments
    {
        IEnumerable<Alignment> Alignments { get; }
    }
}