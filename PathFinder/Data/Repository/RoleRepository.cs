using System.Collections.Generic;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models.Users;

namespace PathFinder.Data.Repository
{
    public class RoleRepository : IAllRoles
    {
        private readonly AppDbContext _appDbContext;

        public RoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Role> Roles => _appDbContext.Roles;
    }
}