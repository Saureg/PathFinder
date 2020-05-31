using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models;

namespace PathFinder.Data.Repository
{
    public class UserRepository : IAllUsers
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<User> Users => _appDbContext.Users;
        
        public User GetUser(int userId) => _appDbContext.Users.FirstOrDefault(x=>x.Id == userId);
    }
}