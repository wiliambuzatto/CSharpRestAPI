using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.Converters
{
    class OrderConverter
    {
        internal Order Convert(OrderBO order)
        {
            return new Order()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Customer = new CustomerConverter().Convert(order.Customer)
            };
        }

        internal OrderBO Convert(Order order)
        {
            return new OrderBO()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Customer = new CustomerConverter().Convert(order.Customer)
            };
        }
    }
}
