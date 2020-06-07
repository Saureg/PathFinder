using System.Collections.Generic;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models.Alignment;

namespace PathFinder.Data.Repository
{
    public class AlignmentRepository : IAllAlignments
    {
        private readonly AppDbContext _appDbContext;

        public AlignmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Alignment> Alignments => _appDbContext.Alignments;
    }
}