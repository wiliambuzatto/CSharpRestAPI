using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public interface IOrderService
    {
        //C
        OrderBO Create(OrderBO order);
        //R
        List<OrderBO> GetAll();
        OrderBO Get(int Id);
        //U
        OrderBO Update(OrderBO order);
        //D
        OrderBO Delete(int Id);
    }
}
