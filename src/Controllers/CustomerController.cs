using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Models;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerDbContext _customerDbContext;

        public CustomerController(ILogger<CustomerController> logger, CustomerDbContext customerDbContext)
        {
            _logger = logger;
            _customerDbContext = customerDbContext;
        }

        [HttpGet]
        [Route("/api/Customers")]
        public ActionResult<IEnumerable<Customer>> GetCustomers(){

            return _customerDbContext.Customers;
        }

        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<Customer>> GetById(int customerId) => await _customerDbContext.Customers.FindAsync(customerId);

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer){
            await _customerDbContext.Customers.AddAsync(customer);
            await _customerDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            _customerDbContext.Customers.Update(customer);
            await _customerDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{customerId:int}")]
        public async Task<ActionResult> Delete(int customerId){
            var customer = await _customerDbContext.Customers.FindAsync(customerId);
            if (customer is null)
            {
                return NotFound();
            }

            _customerDbContext.Customers.Remove(customer);
            await _customerDbContext.SaveChangesAsync();
            return Ok();

        }


    }
}