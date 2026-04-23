using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.View_Model;

namespace Canteen_Order_Management_System.Repo.interfaces
{
    public interface IOrder
    {
        List<Order> GetOrders();
        List<Staff> Role();
        List<User> Role_User();
        Order GetById(int id);
        void Add(Order order);
        void Update(OrderVM vm);
        void Delete(int id);
    }
}
