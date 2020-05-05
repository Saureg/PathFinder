using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;

namespace PathFinder.Data.Repository
{
    public class RaceRepository : IAllRaces
    {
        private readonly AppDbContext _appDbContent;

        public RaceRepository(AppDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Race> Races => _appDbContent.Races;

        public Race GetRace(int raceId) => _appDbContent.Races.FirstOrDefault(r => r.Id == raceId);
    }
}