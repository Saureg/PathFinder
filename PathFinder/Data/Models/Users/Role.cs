using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PathFinder.Data.Models.Users
{
    public class Role
    {
        public int RoleId { get; set; }

        [Display(Name = "Название роли")] public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}