using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Data.Models
{
    public class Item
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; } = 0;

        public string image { get; set; } = string.Empty;
        public List<OrderItems> OrderItems = new();

    }
}
