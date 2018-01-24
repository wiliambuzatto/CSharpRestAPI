using CustomerAppDAL.Entities;
using CustomerAppBLL.BusinessObjects;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        internal Customer Convert(CustomerBO cust)
        {
            return new Customer()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address
            };
        }

        internal CustomerBO Convert(Customer cust)
        {
            return new CustomerBO()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address
            };
        }
    }
}
