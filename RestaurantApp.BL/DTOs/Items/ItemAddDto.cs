using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.Items
{
    public class ItemAddDto
    {
        public string name {  get; set; }=string.Empty;
        public string description { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public decimal price { get; set; } = 0;
        public string image { get; set; } = string.Empty;
    }
}
