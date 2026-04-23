using Canteen_Order_Management_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canteen_Order_Management_System.View_Model
{
    public class StaffVM
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string Status { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public int UserId { get; set; }
    }
}
