using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;
using PathFinder.ViewModels;

namespace PathFinder.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacter _character;
        private readonly IAllRaces _allRaces;
        private readonly IAllClasses _allClasses;

        public CharacterController(ICharacter character, IAllRaces allRaces, IAllClasses allClasses)
        {
            _character = character;
            _allRaces = allRaces;
            _allClasses = allClasses;
        }

        public IActionResult Create()
        {
            var races = _allRaces.Races.ToList();

            var characterViewModel = new CharacterCreateViewModel
            {
                CharClasses = _allClasses.CharClasses.ToList(),
                Races = races.ToList()
            };

            ViewData["Title"] = "Новый персонаж";

            return View(characterViewModel);
        }

        [HttpPost]
        public IActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                _character.CreateCharacter(character);
                return RedirectToAction("Complete");
            }

            var races = _allRaces.Races.ToList();

            var characterViewModel = new CharacterCreateViewModel
            {
                Character = character,
                CharClasses = _allClasses.CharClasses.ToList(),
                Races = races
            };

            return View(characterViewModel);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Персонаж успешно создан!";
            return View();
        }

        [Route("Character/List")]
        public ViewResult List()
        {
            IEnumerable<Character> characters = _character.Characters.OrderBy(c => c.Id);

            var characterViewModel = new CharacterListViewModel
            {
                Characters = characters,
                Races = _allRaces.Races.ToList(),
                CharClasses = _allClasses.CharClasses.ToList()
            };

            ViewData["Title"] = "Персонажи";

            return View(characterViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var character = _character.Characters.FirstOrDefault(x => x.Id == id);
            if (character == null) return NotFound();

            return View(character);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _character.DeleteCharacter(id);
            return RedirectToAction("List");
        }
    }
}