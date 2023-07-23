using RestaurantApp.BL.DTOs.OrderItemsDto;
using RestaurantApp.DAL;
using RestaurantApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL
{
    public class OrderItemsManager : IOrderItemsManager
    {
        private readonly IOrderItemsRepo orderItemrepo;

        public OrderItemsManager(IOrderItemsRepo orderItemrepo)
        {
            this.orderItemrepo = orderItemrepo;
        }
        public int addItems(OrderItemsAddDto item)
        {
            OrderItems additem = new()
            {
                //orderId = item.OrderId,
                itemId = item.itemId,
                quantity = item.quantity
            };
            orderItemrepo.addItems(additem);
            orderItemrepo.SaveChanges();
            return 1;
        }

        public IEnumerable<OrderItemsReadDto> GetByOrderId(int orderId)
        {
           var orderitemfromdb= orderItemrepo.GetByOrderId(orderId);
            return orderitemfromdb.Select(i => new OrderItemsReadDto
            {
                OrderId = i.orderId,
                itemId=i.itemId,
                quantity = i.quantity
            }) ;
        }
    }
}
