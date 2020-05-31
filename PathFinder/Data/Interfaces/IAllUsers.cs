using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Models;

namespace PathFinder.Data.Interfaces
{
    public interface IAllUsers
    {
        DbSet<User> Users { get; }
        
        User GetUser(int userId);
    }
}