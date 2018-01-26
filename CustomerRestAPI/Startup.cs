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
                var facade = new BLLFacade();

                var address = facade.AddressService.Create(new AddressBO
                {
                    City = "Cuiabá",
                    Street = "Barão Melgaço",
                    Number = "1800"
                });

                var cust = facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Wiliam",
                    LastName = "Buzatto",
                    Addresses = new List<AddressBO>() { address }
                });
                facade.CustomerService.Create(new CustomerBO
                {
                    FirstName = "Eduardo",
                    LastName = "Tavares",
                    Addresses = new List<AddressBO>() { address }
                });

                for (int i = 0; i < 10000; i++)
                    facade.OrderService.Create(new OrderBO
                    {
                        OrderDate = DateTime.Now.AddMonths(-1),
                        DeliveryDate = DateTime.Now.AddMonths(1),
                        CustomerId = cust.Id
                    });
                

            }

            app.UseMvc();
        }
    }
}
