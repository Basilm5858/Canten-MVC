using Canteen_Order_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canteen_Order_Management_System.View_Model
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public List<Staff> Staffs { get; set; } = new List<Staff>();
        public int StaffId { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public int UserId { get; set; }
        public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
        public int FoodItemId { get; set; }
    }
}
