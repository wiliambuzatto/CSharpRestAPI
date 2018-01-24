using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<OrderBO> Get()
        {
            return facade.OrderService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public OrderBO Get(int id)
        {
            return facade.OrderService.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO order)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.OrderService.Create(order));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO order)
        {
            if (id != order.Id)
            {
                return BadRequest("Id da url não confere com id do objeto Json");
            }
            try
            {
                return Ok(facade.OrderService.Update(order));
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.OrderService.Delete(id);
        }
    }
}
