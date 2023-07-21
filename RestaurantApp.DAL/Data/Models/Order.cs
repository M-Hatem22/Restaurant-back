using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Data.Models
{
    public class Order
    {
        public int Id { get; set; } = 0;
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        public User user { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal totalPrice { get; set; }= 0;
    }
}
