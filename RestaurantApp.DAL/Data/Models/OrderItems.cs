using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Data.Models
{
    [PrimaryKey("orderId", "itemId")]
    public class OrderItems 
    {
        
        public int orderId { get; set; }
        public Order order { get; set; }
        public int itemId { get; set; }
        public Item item { get; set; }
        public int quantity { get; set; }
    }
}
