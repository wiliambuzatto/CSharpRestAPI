﻿using CustomerAppBLL.Services;
using CustomerAppDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public ICustomerService CustomerService
        {
            get { return new CustomerService(new DALFacade());  }
        }

        public IOrderService OrderService
        {
            get { return new OrderService(new DALFacade()); }
        }
        public IAddressService AddressService
        {
            get { return new AddressService(new DALFacade()); }
        }

    }
}
