using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Canteen_Order_Management_System.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen_Order_Management_System.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly IFoodItem foodItem;
        private readonly IUser user;
        public FoodItemController(IFoodItem foodItem, IUser user)
        {
            this.foodItem = foodItem;
            this.user = user;
        }

        // GET: FoodItemController
        public IActionResult Index()
        {
            var res = foodItem.GetFoodItems();
            return View(res);
        }

        // GET: FoodItemController/Details/5
        public ActionResult Details(int id)
        {
            var res = foodItem.GetById(id);
            return View();
        }

        // GET: FoodItemController/Create
        public IActionResult Create()
        {
            var data = new FoodItemVM()
            {
                Users = user.GetAllUsers()
            };
            return View(data);
        }

        // POST: FoodItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodItemVM collection)
        {
            var res = new FoodItem()
            {
                Category = collection.Category,
                FoodItemId = collection.FoodItemId,
                Name = collection.Name,
                Price = collection.Price,
                UserId = collection.UserId
            };
            foodItem.Add(res);
            return RedirectToAction(nameof(Index));
        }

        // GET: FoodItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodItemController/Edit/5
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

        // GET: FoodItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
