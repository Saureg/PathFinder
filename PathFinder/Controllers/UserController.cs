using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Interfaces;
using PathFinder.ViewModels.User;

namespace PathFinder.Controllers
{
    public class UserController : Controller
    {
        private readonly IAllUsers _allUsers;

        public UserController(IAllUsers allAllUsers)
        {
            _allUsers = allAllUsers;
        }
        
        public IActionResult Index()
        {
            return View();
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
    }
}