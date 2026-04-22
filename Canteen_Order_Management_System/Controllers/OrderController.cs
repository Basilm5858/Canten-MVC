using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Canteen_Order_Management_System.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                Users = user.GetAllUsers(),
                FoodItems = foodItem.GetFoodItems(),
                Staffs = order.Rule(),
            };
            return View(data);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM collection)
        {
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
            res.Staff.Status = "Busy";
            
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = order.GetById(id);
            return View(res);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            order.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
