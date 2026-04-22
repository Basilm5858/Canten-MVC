using Canteen_Order_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canteen_Order_Management_System.View_Model
{
    public class FoodItemVM
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public int UserId { get; set; }
    }
}
