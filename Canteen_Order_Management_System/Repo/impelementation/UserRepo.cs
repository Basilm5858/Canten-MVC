using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;

namespace Canteen_Order_Management_System.Repo.impelementation
{
    public class UserRepo : IUser
    {
        private readonly My_AppContext _c;
        public UserRepo(My_AppContext c)
        {
            _c = c;
        }
        public List<User> GetAllUsers()
        {
            return _c.Users.ToList();
        }
        public User GetById(int id)
        {
            return _c.Users.Find(id);
        }
        public void Add(User user)
        {
            _c.Users.Add(user);
            _c.SaveChanges();
        }
        public void Update(User user)
        {
            _c.Users.Update(user);
            _c.SaveChanges();
        }
        public void Delete(int id)
        {
            var res = _c.Users.Find(id);
            if(res != null)
            {
                _c.Users.Remove(res);
                _c.SaveChanges();
            }
        }
    }
}
