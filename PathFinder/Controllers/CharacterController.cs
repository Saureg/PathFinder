using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAllUsers _allUsers;

        public CharacterController(ICharacter character, IAllRaces allRaces, IAllClasses allClasses, IAllUsers allUsers)
        {
            _character = character;
            _allRaces = allRaces;
            _allClasses = allClasses;
            _allUsers = allUsers;
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
        [Authorize]
        public IActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                var userId = _allUsers.Users.FirstOrDefault(u => u.Email == User.Identity.Name)?.Id;
                if (userId != null)
                {
                    character.UserId = userId.Value;   
                }
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

        [Authorize]
        [Route("Character/List")]
        public ViewResult List()
        {
            IEnumerable<Character> characters = _character.Characters.OrderBy(c => c.Id);

            if (User.IsInRole("user"))
            {
                var userId = _allUsers.Users.FirstOrDefault(u => u.Email == User.Identity.Name)?.Id;
                characters = characters.Where(c => c.UserId == userId);
            }
            
            var characterViewModel = new CharacterListViewModel
            {
                Characters = characters,
                Races = _allRaces.Races.ToList(),
                CharClasses = _allClasses.CharClasses.ToList(),
                Users = _allUsers.Users
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