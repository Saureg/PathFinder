
namespace PathFinder.Data.Models.CharClass
{
    
    public class ClassAlignment
    {
        public int AlignmentId { get; set; }
        
        public Alignment.Alignment Alignment { get; set; }
        
        public int CharClassId { get; set; }
        
        public CharClass CharClass { get; set; }
    }
}