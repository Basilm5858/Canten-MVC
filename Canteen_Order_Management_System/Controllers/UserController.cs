using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen_Order_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser repo;
        public UserController(IUser repo)
        {
            this.repo = repo;
        }

        // GET: UserController
        public IActionResult Index()
        {
            var res = repo.GetAllUsers();
            return View(res);
        }

        // GET: UserController/Details/5
        public IActionResult Details(int id)
        {
            var res = repo.GetById(id);
            return View(res);
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User collection)
        {
            repo.Add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Edit/5
        public IActionResult Edit(int id)
        {
            var res = repo.GetById(id);
            return View(res);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User collection)
        {
            repo.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public IActionResult Delete(int id)
        {
            var res = repo.GetById(id);
            return View(res);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
