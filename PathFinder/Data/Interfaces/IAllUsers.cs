using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Models.Users;

namespace PathFinder.Data.Interfaces
{
    public interface IAllUsers
    {
        DbSet<User> Users { get; }

        User GetUser(int userId);

        void EditUser(User user);

        void CreateUser(User user);

        void DeleteUser(int userId);
    }
}