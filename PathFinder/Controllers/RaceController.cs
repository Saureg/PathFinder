using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int raceId)
        {
            var race = _allRaces.Races.Single(x => x.Id == raceId);

            ViewData["Title"] = race.Name;

            return View(race);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(Race race)
        {
            ViewData["Success"] = false;
            if (ModelState.IsValid)
            {
                _allRaces.EditRace(race);
                ViewData["Success"] = true;
            }

            ViewData["Title"] = race.Name;
            return View(race);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["Title"] = "Новая раса";

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(Race race)
        {
            if (ModelState.IsValid)
            {
                _allRaces.CreateRace(race);
                ViewData["Success"] = true;
                return RedirectToAction("List");
            }

            return View(race);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? raceId)
        {
            if (raceId == null) return NotFound();

            var race = _allRaces.Races.FirstOrDefault(x => x.Id == raceId);
            if (race == null) return NotFound();

            return View(race);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int raceId)
        {
            _allRaces.DeleteRace(raceId);
            return RedirectToAction("List");
        }

        public JsonResult SuggestList()
        {
            IEnumerable<Race> races = _allRaces.Races.OrderBy(x => x.Id);

            return Json(races);
        }
    }
}