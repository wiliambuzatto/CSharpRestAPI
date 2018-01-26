using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Converters
{
    class OrderConverter
    {
        internal Order Convert(OrderBO order)
        {
            if (order == null) { return null; }
            return new Order()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                //Customer = new CustomerConverter().Convert(order.Customer),
                CustomerId = order.CustomerId
            };
        }

        internal OrderBO Convert(Order order)
        {
            if (order == null) { return null; }
            return new OrderBO()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Customer = new CustomerConverter().Convert(order.Customer),
                CustomerId = order.CustomerId
            };
        }
    }
}
