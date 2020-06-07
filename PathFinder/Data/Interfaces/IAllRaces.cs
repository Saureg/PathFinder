using System.Collections.Generic;
using PathFinder.Data.Models;

namespace PathFinder.Data.Interfaces
{
    public interface IAllRaces
    {
        IEnumerable<Race> Races { get; }

        Race GetRace(int raceId);

        void EditRace(Race race);

        void CreateRace(Race race);

        void DeleteRace(int raceId);
    }
}