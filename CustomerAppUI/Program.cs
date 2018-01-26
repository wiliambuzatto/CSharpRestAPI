using CustomerAppBLL;
using CustomerAppDAL.Entities;
using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;

namespace CustomerAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {
            var address = new AddressBO
            {
                City = "Cuiabá",
                Street = "Barão Melgaço",
                Number = "1800"
            };

            var cust1 = new CustomerBO()
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Addresses = new List<AddressBO>() { address }
            };
            bllFacade.CustomerService.Create(cust1);
            //customers.add(cust1);

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Addresses = new List<AddressBO>() { address }
            });

            string[] menuItems = {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };


            //Show Menu
            //Wait for Selection
            // - Show selection or
            // - Warning and go back to menu

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomer();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            if (customer != null)
            {
                Console.WriteLine("FirstName: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("LastName: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                //customer.Address = Console.ReadLine();
                bllFacade.CustomerService.Update(customer);

                bllFacade.CustomerService.Update(customer);
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }          

        }

        private static CustomerBO FindCustomerById()
        {
            Console.WriteLine("Insert customer id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bllFacade.CustomerService.Get(id);
        }

        private static void DeleteCustomer()
        {
            var customerFound = FindCustomerById();
            if (customerFound != null)
            {
                bllFacade.CustomerService.Delete(customerFound.Id);
            }

            var response = customerFound == null ? "Customer not found" : "Customer not found";
            Console.WriteLine(response);


        }

        private static void AddCustomers()
        {
            Console.WriteLine("Firstname: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Lastname: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            //var address = Console.ReadLine();

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = firstName,
                LastName = lastName//,
                //Addresses = address
            });
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in bllFacade.CustomerService.GetAll())
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FullName} " +
                                $"Adress: {customer.AddressIds}");
            }
            Console.WriteLine("\n");

        }


        // Menu console
        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}
