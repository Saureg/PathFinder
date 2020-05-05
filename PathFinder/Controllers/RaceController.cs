using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;
using PathFinder.ViewModels;

namespace PathFinder.Controllers
{
    public class RaceController : Controller
    {
        private readonly IAllRaces _allRaces;

        public RaceController(IAllRaces allRaces)
        {
            _allRaces = allRaces;
        }

        [Route("Race/List")]
        public ViewResult List()
        {
            IEnumerable<Race> races = _allRaces.Races.OrderBy(x => x.Id);
            
            var raceObj = new RaceListViewModel
            {
                AllRaces = races
            };

            ViewData["Title"] = "Расы";
            
            return View(raceObj);
        }
    }
}