using System.Linq;
using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Interfaces;
using PathFinder.Data.Models.Users;

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

        public User GetUser(int userId)
        {
            return _appDbContext.Users.FirstOrDefault(x => x.Id == userId);
        }

        public void EditUser(User user)
        {
            var currentUser = GetUser(user.Id);

            if (currentUser == null) return;

            _appDbContext.Entry(currentUser).CurrentValues.SetValues(user);

            _appDbContext.SaveChanges();
        }

        public void CreateUser(User user)
        {
            _appDbContext.Users.Add(user);

            _appDbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var currentUser = _appDbContext.Users.SingleOrDefault(u => u.Id == userId);

            if (currentUser == null) return;

            _appDbContext.Users.Remove(currentUser);

            _appDbContext.SaveChanges();
        }
    }
}