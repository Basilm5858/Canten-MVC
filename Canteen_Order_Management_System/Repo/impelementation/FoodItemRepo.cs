using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.Repo.interfaces;
using Canteen_Order_Management_System.View_Model;
using Microsoft.EntityFrameworkCore;

namespace Canteen_Order_Management_System.Repo.impelementation
{
    public class FoodItemRepo : IFoodItem
    {
        private readonly My_AppContext _c;
        public FoodItemRepo(My_AppContext c)
        {
            _c = c;
        }
        public List<FoodItem> GetFoodItems()
        {
            return _c.FoodItems
                .Include(x => x.User)
                .ToList();
        }
        public FoodItem GetById(int id)
        {
            return _c.FoodItems
               .Include(x => x.User)
               .FirstOrDefault(x => x.FoodItemId == id);
        }
        public void Add(FoodItem item)
        {
            _c.FoodItems.Add(item);
            _c.SaveChanges();
        }
        public void Update(FoodItemVM vm)
        {
            var exi = _c.FoodItems.Find(vm.FoodItemId);
            if (exi != null)
            {
                exi.FoodItemId = vm.FoodItemId;
                exi.Price = vm.Price;
                exi.Category = vm.Category;
                exi.UserId = vm.UserId;
                exi.Name = vm.Name;
            }
            _c.SaveChanges();
        }
        public void Delete(int id)
        {
            var res = _c.FoodItems.Find(id);
            if (res != null)
            {
                _c.FoodItems.Remove(res);
            }
        }
    }
}
