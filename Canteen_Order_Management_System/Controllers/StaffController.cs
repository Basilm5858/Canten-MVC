using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Canteen_Order_Management_System.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen_Order_Management_System.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaff staff;
        private readonly IUser user;
        public StaffController(IStaff staff, IUser user)
        {
            this.staff = staff;
            this.user = user;
        }

        // GET: StaffController
        public IActionResult Index()
        {
            var res = staff.GetAllStaff();
            return View(res);
        }

        // GET: StaffController/Details/5
        public IActionResult Details(int id)
        {
            var res = staff.GetById(id);
            return View(res);
        }

        // GET: StaffController/Create
        public IActionResult Create()
        {
            var data = new StaffVM()
            {
                Users = user.GetAllUsers()
            };
            return View(data);
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffVM collection)
        {
            var res = new Staff()
            {
                StaffId = collection.StaffId,
                Status = collection.Status,
                Name = collection.Name,
                Phone = collection.Phone,
                UserId = collection.UserId,
            };
            staff.AddStaff(res);
            return RedirectToAction(nameof(Index));
        }

        // GET: StaffController/Edit/5
        public IActionResult Edit(int id)
        {
            var res = staff.GetById(id);
            var data = new StaffVM()
            {
                StaffId = res.StaffId,
                Status = res.Status,
                Name = res.Name,
                Phone = res.Phone,
                Users = user.GetAllUsers(),
                UserId = res.UserId,

            };
            return View(data);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StaffVM collection)
        {
            staff.UpdateStaff(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: StaffController/Delete/5
        public IActionResult Delete(int id)
        {
            var res = staff.GetById(id);
            return View(res);
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            staff.DeleteStaff(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
