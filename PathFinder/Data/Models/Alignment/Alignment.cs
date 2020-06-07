using System.Collections.Generic;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.Data.Models.Alignment
{
    public class Alignment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ClassAlignment> ClassAlignments { get; set; }
    }
}