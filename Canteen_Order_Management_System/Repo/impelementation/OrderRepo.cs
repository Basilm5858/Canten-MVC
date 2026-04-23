using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Canteen_Order_Management_System.View_Model;
using Microsoft.EntityFrameworkCore;

namespace Canteen_Order_Management_System.Repo.impelementation
{
    public class OrderRepo : IOrder
    {
        private readonly My_AppContext _c;
        public OrderRepo(My_AppContext c)
        {
            _c = c;
        }
        public List<Order> GetOrders()
        {
            return _c.Orders
                .Include(x => x.User)
                .Include(x => x.Staff)
                .Include(x => x.FoodItem)
                .ToList();
        }
        public Order GetById(int id)
        {
            return _c.Orders
                 .Include(x => x.User)
                 .Include(x => x.Staff)
                 .Include(x => x.FoodItem)
                 .FirstOrDefault(x => x.OrderId == id);
        }

        public List<Staff> Role()
        {
            return _c.staffs
                .Where(x => x.Status == "Available")
                .ToList();
        }
        public List<User> Role_User()
        {
            return _c.Users
                .Where(x => x.Role == "Customer")
                .ToList();
        }
        public void Add(Order order)
        {
            var staff = _c.staffs.FirstOrDefault(s => s.StaffId == order.StaffId);

            _c.Orders.Add(order);

            staff.Status = "Busy";

            _c.SaveChanges();
        }
      
        public void Update(OrderVM vm)
        {
            var exi = _c.Orders.Find(vm.StaffId);
            if(exi != null)
            {
                if (exi.TotalPrice > 0)
                {
                    exi.OrderId = vm.OrderId;
                    exi.Status = vm.Status;
                    exi.OrderDateTime = vm.OrderDateTime;
                    exi.StaffId = vm.StaffId;
                    exi.TotalPrice = vm.TotalPrice;
                    exi.UserId = vm.UserId;
                    exi.FoodItemId = vm.FoodItemId;
                    exi.UserId = vm.UserId;
                }
                else
                {
                    throw new Exception("The Total Price Must Be More Than 0");
                }
            }
            

            _c.SaveChanges();
        }
        public void Delete(int id)
        {
            var res = _c.Orders.Find(id);

            if (res != null)
            {
                var staff = _c.staffs.FirstOrDefault(s => s.StaffId == res.StaffId);

                if (staff != null && staff.Status == "Busy")
                {
                    staff.Status = "Available";
                }

                _c.Orders.Remove(res);
                _c.SaveChanges();
            }
        }
    }
}
