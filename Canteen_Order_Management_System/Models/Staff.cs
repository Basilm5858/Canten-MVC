using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canteen_Order_Management_System.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}

//StaffId: Unique identifier
//●	Name: Required
//●	JobTitle: (Chef / Cashier / Server) — Required
//●	Phone: Required, 11 digits
//●	Status: (Available / Busy)
//●	CreatedByUserId: Admin who added the staff
