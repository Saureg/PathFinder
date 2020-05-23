
namespace PathFinder.Data.Models.CharClass
{
    
    public class ClassAlignment
    {
        public int AlignmentId { get; set; }
        
        public virtual Alignment.Alignment Alignment { get; set; }
        
        public int CharClassId { get; set; }
        
        public virtual CharClass CharClass { get; set; }
    }
}