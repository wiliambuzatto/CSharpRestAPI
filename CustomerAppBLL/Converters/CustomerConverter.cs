using CustomerAppDAL.Entities;
using CustomerAppBLL.BusinessObjects;
using System.Linq;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        private AddressConverter aConv;

        public CustomerConverter()
        {
            aConv = new AddressConverter();
        }
        internal Customer Convert(CustomerBO cust)
        {
            if (cust == null) { return null; }
            return new Customer()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Addresses = cust.AddressIds?.Select(aId => new CustomerAddress()
                {
                    AddressId = aId,
                    CustomerId = cust.Id
                }).ToList()
            };
        }

        internal CustomerBO Convert(Customer cust)
        {
            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                /*Addresses = cust.Addresses.Select(a => new AddressBO() {
                    Id = a.CustomerId,
                    City = a.Address?.City,
                    Number = a.Address?.Number,
                    Street = a.Address?.Street
                }).ToList(),*/
                AddressIds = cust.Addresses?.Select(a => a.AddressId).ToList(),
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}
