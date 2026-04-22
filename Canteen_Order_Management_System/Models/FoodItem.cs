using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canteen_Order_Management_System.Models
{
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

//FoodItemId: Unique identifier
//●	Name: (Burger, Pizza, Sandwich, Juice…) — Required
//●	Price: Must be greater than 0
//●	Category: (Meal / Drink / Snack) — Required
//●	CreatedByUserId: Admin who created it
