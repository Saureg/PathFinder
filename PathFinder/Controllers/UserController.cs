using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Interfaces;

namespace PathFinder.Controllers
{
    public class UserController : Controller
    {
        private readonly IAllUsers _users;

        public UserController(IAllUsers allUsers)
        {
            _users = allUsers;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Profile()
        {
            var user = _users.Users.Include(r => r.Role).FirstOrDefault(u => u.Email == User.Identity.Name);
            
            if (user == null)
            {
                return NotFound();
            }
            
            ViewData["Title"] = "Профиль";
            return View(user);
        }
    }
}