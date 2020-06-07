using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models.Users;
using PathFinder.ViewModels.User;

namespace PathFinder.Controllers
{
    public class UserController : Controller
    {
        private readonly IAllUsers _allUsers;
        private readonly IAllRoles _allRoles;

        public UserController(IAllUsers allUsers, IAllRoles allRoles)
        {
            _allUsers = allUsers;
            _allRoles = allRoles;
        }
        
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var users = _allUsers.Users.Include(u => u.Role).OrderBy(u => u.Id).ToList();
            
            return View(users);
        }
        
        public IActionResult Profile()
        {
            var user = _allUsers.Users.Include(r => r.Role).FirstOrDefault(u => u.Email == User.Identity.Name);
            
            if (user == null)
            {
                return NotFound();
            }
            
            var profileViewModel = new ProfileViewModel
            {
                Email = user.Email,
                Name = user.Name,
                RoleName = user.Role.Name
            };

            ViewData["ProfileSuccess"] = false;
            ViewData["Title"] = "Профиль";
            return View(profileViewModel);
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel profileViewModel)
        {
            var currentUser = _allUsers.Users.Include(r => r.Role).FirstOrDefault(u => u.Email == User.Identity.Name);

            if (currentUser == null)
            {
                return NotFound();
            }

            currentUser.Email = profileViewModel.Email;
            currentUser.Name = profileViewModel.Name;

            if (profileViewModel.NewPassword != null && profileViewModel.NewPassword == profileViewModel.ConfirmPassword)
            {
                currentUser.Password = profileViewModel.NewPassword;
            }
            
            if (ModelState.IsValid)
            {
                ViewData["ProfileSuccess"] = true;
                _allUsers.EditUser(currentUser);
            }
            else
            {
                ViewData["ProfileSuccess"] = false;
            }

            profileViewModel.RoleName = currentUser.Role.Name;
                
            ViewData["Title"] = "Профиль";
            return View(profileViewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["Title"] = "Новый пользователь";
            
            var userViewModel = new UserViewModel
            {
                Roles = _allRoles.Roles.OrderBy(x=>x.Name).ToList()
            };
            
            return View(userViewModel);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _allUsers.CreateUser(user);
                return RedirectToAction("Complete", new {userId = user.Id});
            }

            var userViewModel = new UserViewModel
            {
                User = user,
                Roles = _allRoles.Roles.OrderBy(x=>x.Name).ToList()
            };
            
            return View(userViewModel);
        }
        
        [Authorize(Roles = "admin")]
        public IActionResult Complete(int userId)
        {
            return View(userId);
        }

        public IActionResult Edit(int userId)
        {
            var user = _allUsers.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            
            var userViewModel = new UserViewModel
            {
                User = user,
                Roles = _allRoles.Roles.OrderBy(x=>x.Name).ToList()
            };

            return View(userViewModel);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _allUsers.EditUser(user);
                return RedirectToAction("Complete", new {userId = user.Id});
            }

            var userViewModel = new UserViewModel
            {
                User = user,
                Roles = _allRoles.Roles.OrderBy(x=>x.Name).ToList()
            };
            
            return View(userViewModel);
        }
        
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? userId)
        {
            if (userId == null) return NotFound();
            
            var user = _allUsers.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null) return NotFound();

            return View(user);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int userId)
        {
            _allUsers.DeleteUser(userId);
            return RedirectToAction("Index");
        }
    }
}