using System.Collections.Generic;
using PathFinder.Data.Models.Alignment;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.ViewModels
{
    public class ClassViewModel
    {
        public CharClass CharClass { get; set; }
        
        public List<Alignment> Alignments { get; set; }
        
        public List<Alignment> SelectedAlignments { get; set; }
    }
}