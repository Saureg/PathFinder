using System.Collections.Generic;
using PathFinder.Data.Models.Users;

namespace PathFinder.Data.Interfaces
{
    public interface IAllRoles
    {
        IEnumerable<Role> Roles { get; }
    }
}