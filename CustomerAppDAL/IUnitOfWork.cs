using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get;  }
        IOrderRepository OrderRepository { get; }

        int Complete();
    }
}
