using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models.CharClass;
using PathFinder.ViewModels;

namespace PathFinder.Controllers
{
    public class ClassController : Controller
    {
        private readonly IAllClasses _allClasses;
        private readonly IAllAlignments _allAlignments;

        public ClassController(IAllClasses allClasses, IAllAlignments allAlignments)
        {
            _allClasses = allClasses;
            _allAlignments = allAlignments;
        }

        public IActionResult List(int? id)
        {
            if (id != null)
            {
                var charClass = _allClasses.GetClass(id.Value);
                ViewData["Title"] = charClass.Name;
                return View("Item", charClass);
            }

            IEnumerable<CharClass> charClasses = _allClasses.CharClasses.OrderBy(x => x.Id);
            ViewData["Title"] = "Классы";
            return View(charClasses);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["Title"] = "Новый класс";

            var classViewModel = new ClassViewModel
            {
                Alignments = _allAlignments.Alignments.ToList()
            };

            return View(classViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(CharClass charClass)
        {
            if (ModelState.IsValid)
            {
                _allClasses.CreateClass(charClass);
                return RedirectToAction("Complete", new {classId = charClass.Id});
            }

            var classViewModel = new ClassViewModel
            {
                CharClass = charClass,
                Alignments = _allAlignments.Alignments.ToList()
            };

            return View(classViewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? classId)
        {
            if (classId == null) return NotFound();

            var charClass = _allClasses.CharClasses.FirstOrDefault(x => x.Id == classId);
            if (charClass == null) return NotFound();

            return View(charClass);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int classId)
        {
            _allClasses.DeleteClass(classId);
            return RedirectToAction("List");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int classId)
        {
            var charClass = _allClasses.GetClass(classId);
            if (charClass == null) return NotFound();

            var classViewModel = new ClassViewModel
            {
                Alignments = _allAlignments.Alignments.ToList(),
                CharClass = charClass
            };

            ViewData["Title"] = charClass.Name;
            return View(classViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(CharClass charClass)
        {
            if (ModelState.IsValid)
            {
                _allClasses.EditClass(charClass);
                return RedirectToAction("Complete", new {classId = charClass.Id});
            }

            var classViewModel = new ClassViewModel
            {
                CharClass = charClass,
                Alignments = _allAlignments.Alignments.ToList()
            };

            ViewData["Title"] = charClass.Name;
            return View(classViewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Complete(int classId)
        {
            return View(classId);
        }
    }
}