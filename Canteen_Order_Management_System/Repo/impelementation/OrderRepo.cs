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

        public List<Staff> Rule()
        {
            return _c.staffs
                .Where(x => x.Status == "Available")
                .ToList();
        }
        public void Add(Order order)
        {
            _c.Orders.Add(order);
            _c.SaveChanges();
            
        }
      
        public void Update(OrderVM vm)
        {
            var exi = _c.Orders.Find(vm.StaffId);
            if(exi != null)
            {
                exi.OrderId = vm.OrderId;
                exi.Status = vm.Status;
                exi.OrderDateTime = vm.OrderDateTime;
                exi.StaffId = vm.StaffId;
                exi.TotalPrice = vm.TotalPrice;
                exi.UserId = vm.UserId;
            }
            _c.SaveChanges();
        }
        public void Delete(int id)
        {
            var res = _c.Orders.Find(id);
            if(res != null)
            {
                _c.Orders.Remove(res);
                _c.SaveChanges();
            }
        }
    }
}
