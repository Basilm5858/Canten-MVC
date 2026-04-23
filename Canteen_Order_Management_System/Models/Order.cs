using Azure.Core;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canteen_Order_Management_System.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDateTime { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public string Status {  get; set; }
        [Required]
        public Staff Staff { get; set; }
        [ForeignKey("StaffId")]
        public int StaffId { get; set;}
        public User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public FoodItem FoodItem { get; set; }
        [ForeignKey("FoodItemId")]
        public int FoodItemId { get; set; }
    }
}

//OrderId: Unique identifier
//●	OrderDateTime: Required
//●	TotalPrice: Must be greater than 0
//●	Status: (Requested / Preparing / Ready / Completed / Cancelled)
//●	StaffId: Assigned staff
//●	FoodItemId: Selected item
//●	UserId: Customer who made the order
