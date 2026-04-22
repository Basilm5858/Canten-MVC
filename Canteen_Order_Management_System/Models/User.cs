using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Canteen_Order_Management_System.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(9,ErrorMessage ="The Password Must Be More Than 8" )]
        public string Password { get; set; }
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }
        public List<Staff> Staffs { get; set; } = new List<Staff>();
        public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
        public List<Order> OrderItems { get; set; }  = new List<Order>();

    }
}

//UserId: Unique identifier
//●	Name: Required
//●	Email: Required, must be valid
//●	Password: Required, more than 8 characters
//●	Phone: Required, 11 digits
//●	Role: (Admin / Customer)
