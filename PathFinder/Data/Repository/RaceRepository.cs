using System.Collections.Generic;
using System.Linq;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;

namespace PathFinder.Data.Repository
{
    public class RaceRepository : IAllRaces
    {
        private readonly AppDbContext _appDbContext;

        public RaceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Race> Races => _appDbContext.Races;

        public Race GetRace(int raceId) => _appDbContext.Races.FirstOrDefault(r => r.Id == raceId);
        
        public void EditRace(Race race)
        {
            var currentRace = _appDbContext.Races.SingleOrDefault(r => r.Id == race.Id);
            
            if (currentRace == null)
            {
                return;
            }
            
            _appDbContext.Entry(currentRace).CurrentValues.SetValues(race);
   
            _appDbContext.SaveChanges();
        }

        public void CreateRace(Race race)
        {
            _appDbContext.Races.Add(race);
            _appDbContext.SaveChanges();
        }

        public void DeleteRace(int raceId)
        {
            var currentRace = _appDbContext.Races.SingleOrDefault(r => r.Id == raceId);
            
            if (currentRace == null)
            {
                return;
            }
            
            _appDbContext.Races.Remove(currentRace);

            _appDbContext.SaveChanges();
        }
    }
}