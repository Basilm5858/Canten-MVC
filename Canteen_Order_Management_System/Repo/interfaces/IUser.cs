using Canteen_Order_Management_System.Models;

namespace Canteen_Order_Management_System.Repo.interfaces
{
    public interface IUser
    {
        List<User> GetAllUsers();
        User GetById(int id);
        void Update(User user);
        void Add(User user);
        void Delete(int id);
    }
}
