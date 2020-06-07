using System.Collections.Generic;
using PathFinder.Data.Models.Users;

namespace PathFinder.ViewModels.User
{
    public class UserViewModel
    {
        public Data.Models.Users.User User { get; set; }
        
        public List<Role> Roles { get; set; }
    }
}