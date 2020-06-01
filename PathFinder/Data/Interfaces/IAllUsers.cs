using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Models;
using PathFinder.Data.Models.Users;

namespace PathFinder.Data.Interfaces
{
    public interface IAllUsers
    {
        DbSet<User> Users { get; }
        
        User GetUser(int userId);
    }
}