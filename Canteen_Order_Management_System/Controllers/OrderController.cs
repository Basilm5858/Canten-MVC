using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Canteen_Order_Management_System.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Canteen_Order_Management_System.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder order;
        private readonly IFoodItem foodItem;
        private readonly IUser user;
        private readonly IStaff staff;

        public OrderController(IOrder order, IFoodItem foodItem, IUser user, IStaff staff)
        {
            this.order = order;
            this.foodItem = foodItem;
            this.user = user;
            this.staff = staff;
        }


        // GET: OrderController
        public IActionResult Index()
        {
            var res = order.GetOrders();
            return View(res);
        }

        // GET: OrderController/Details/5
        public IActionResult Details(int id)
        {
            var res = order.GetById(id);
            return View(res);
        }

        // GET: OrderController/Create
        public IActionResult Create()
        {
            var data = new OrderVM()
            {
                Users = order.Role_User(),
                FoodItems = foodItem.GetFoodItems(),
                Staffs = order.Role(),
            };
            return View(data);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderVM collection)
        {
            if(collection.TotalPrice < 1)
            {
                throw new ArgumentException("The Total Price Must Be More Than 0");
            }
            var res = new Order()
            {
                StaffId = collection.StaffId,
                Status = collection.Status,
                FoodItemId = collection.FoodItemId,
                OrderDateTime = collection.OrderDateTime,
                TotalPrice = collection.TotalPrice,
                UserId = collection.UserId,
                OrderId = collection.OrderId,
            };

            order.Add(res);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = order.GetById(id);
            var data = new OrderVM()
            {
                Users = order.Role_User(),
                FoodItems = foodItem.GetFoodItems(),
                Staffs = order.Role(),
                StaffId = res.StaffId,
                Status = res.Status,
                FoodItemId = res.FoodItemId,
                OrderDateTime = res.OrderDateTime,
                OrderId = res.OrderId,
                TotalPrice = res.TotalPrice,
                UserId = res.UserId,
                
            };
            return View(data);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderVM collection)
        {
            order.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Delete/5
        public IActionResult Delete(int id)
        {
            var res = order.GetById(id);
            return View(res);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id , IFormCollection collection)
        {
            order.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
