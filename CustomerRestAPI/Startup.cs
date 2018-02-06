using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                /*var facade = new BLLFacade();

                var address = facade.AddressService.Create(
                    new AddressBO() {
                        City = "Cuiabá",
                        Street = "Barão Melgaço",
                        Number = "1800"
                    });

                var address2 = facade.AddressService.Create(
                     new AddressBO()
                     {
                         City = "Chapada",
                         Street = "Barão Melgaço",
                         Number = "1800"
                     });
                var address3 = facade.AddressService.Create(
                     new AddressBO()
                     {
                         City = "Querência",
                         Street = "Barão Melgaço",
                         Number = "1800"
                     });

                var cust = facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        FirstName = "Wiliam",
                        LastName = "Buzatto",
                        AddressIds = new List<int>() { address.Id, address3.Id }
                        
                    });
                facade.CustomerService.Create(
                    new CustomerBO()
                        {
                            FirstName = "Eduardo",
                            LastName = "Tavares",
                        AddressIds = new List<int>() { address.Id, address2.Id }
                    });

                for (int i = 0; i < 5; i++)
                    facade.OrderService.Create(new OrderBO
                    {
                        OrderDate = DateTime.Now.AddMonths(-1),
                        DeliveryDate = DateTime.Now.AddMonths(1),
                        CustomerId = cust.Id
                    });
                    */
                

            }

            app.UseMvc();
        }
    }
}
