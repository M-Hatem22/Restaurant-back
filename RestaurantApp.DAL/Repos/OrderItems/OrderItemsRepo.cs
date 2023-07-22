using RestaurantApp.DAL.Data.Context;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL
{
    public class OrderItemsRepo : IOrderItemsRepo
    {
        private readonly UserContext context;

        public OrderItemsRepo(UserContext context)
        {
            this.context = context;
        }
        public int addItems(Data.Models.OrderItems item)
        {
            context.Add(item);
            SaveChanges();
            return 1;
        }

        public int deleteItems(Data.Models.OrderItems item)
        {
            context.Set<Data.Models.OrderItems>().Remove(item);
            return 1;
        }

        public IEnumerable<Data.Models.OrderItems> GetByOrderId(int orderId)
        {
            return context.Set<Data.Models.OrderItems>().Where(a => a.orderId == orderId);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
