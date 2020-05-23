using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.Controllers
{
    public class ClassController : Controller
    {
        private readonly IAllClasses _allClasses;

        public ClassController(IAllClasses allClasses)
        {
            _allClasses = allClasses;
        }
        
        public IActionResult List()
        {
            IEnumerable<CharClass> charClasses = _allClasses.CharClasses.OrderBy(x => x.Id);
            
            ViewData["Title"] = "Классы";
            
            return View(charClasses);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Новый класс";

            return View();
        }

        [HttpPost]
        public IActionResult Create(CharClass charClass)
        {
            if (ModelState.IsValid)
            {
                _allClasses.CreateClass(charClass);
                return RedirectToAction("List");
            }

            return View(charClass);
        }
        
        public IActionResult Delete(int? classId)
        {
            if (classId == null) return NotFound();

            var charClass = _allClasses.CharClasses.FirstOrDefault(x => x.Id == classId);
            if (charClass == null) return NotFound();

            return View(charClass);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int classId)
        {
            _allClasses.DeleteClass(classId);
            return RedirectToAction("List");
        }
    }
}