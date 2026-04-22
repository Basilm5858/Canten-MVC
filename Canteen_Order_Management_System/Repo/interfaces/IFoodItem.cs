using Canteen_Order_Management_System.Models;
using Canteen_Order_Management_System.View_Model;

namespace Canteen_Order_Management_System.Repo.interfaces
{
    public interface IFoodItem
    {
        List<FoodItem> GetFoodItems();
        FoodItem GetById(int id);
        void Add(FoodItem foodItem);
        void Update(FoodItemVM vm);
        void Delete(int id);
    }
}
