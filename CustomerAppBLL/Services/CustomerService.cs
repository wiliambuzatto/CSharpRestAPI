using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL;
using System.Linq;
using CustomerAppDAL.Entities;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;

namespace CustomerAppBLL.Services
{
    public class CustomerService : ICustomerService
    {
        CustomerConverter conv = new CustomerConverter();
        AddressConverter aConv = new AddressConverter();
        DALFacade facade;

        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }


        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();
                return conv.Convert(newCust);
            }            
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newCust);
            }  
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                //1. Get and convert the Customer
                var cust = conv.Convert(uow.CustomerRepository.Get(Id));
                //2. Get All related address from AddressRepository using addressIds
                /*cust.Addresses = cust.AddressIds?
                                .Select(id => aConv.Convert(uow.AddressRepository.Get(id)))
                                .ToList();*/


                cust.Addresses = uow.AddressRepository.GetAllById(cust.AddressIds)
                                    .Select(a => aConv.Convert(a))
                                    .ToList();
                //var addresses = uow.AddressRepository.Get()
                //3. Convert and Add the Address to the CustomerBO
                //4. Return the Customer
                return cust;
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Customer -> CustomerBO
                //return uow.CustomerRepository.GetAll();
                //return uow.CustomerRepository.GetAll().Select(c => conv.Convert(c)).ToList();
                return uow.CustomerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                var customerUpdated = conv.Convert(cust);
                customerFromDb.FirstName = customerUpdated.FirstName;
                customerFromDb.LastName = customerUpdated.LastName;
                //customerFromDb.Addresses = customerUpdated.Addresses;

                //1. Remover todos endereços, exeto o "antigo" que iremos manter. Evitar o problema do vinculo ()
                customerFromDb.Addresses.RemoveAll(ca => !customerUpdated.Addresses.Exists(
                                                                                    a => a.AddressId == ca.AddressId &&
                                                                                    a.CustomerId == ca.CustomerId));
                //2. Remover todos os Ids que já estão no banco, vindo de customerFromDb
                customerUpdated.Addresses.RemoveAll(ca => customerFromDb.Addresses.Exists(
                                                                                a => a.AddressId == ca.AddressId &&
                                                                                a.CustomerId == ca.CustomerId));
                //3. Adicionar o novo CustomerAddress que ainda não estão no banco
                customerFromDb.Addresses.AddRange(
                        customerUpdated.Addresses
                    );

                uow.Complete();
                return conv.Convert(customerFromDb);
            }
            
            
        }
    }
}
