using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS_Assignment.Models;
using System.Collections;

namespace ITS_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly CusomerDataContext _context;
        public CustomerController(CusomerDataContext context)
        {
            _context = context;
        }

        [HttpGet]
      
        public IEnumerable<CustomerDatum> GetAllCustomers()
        {
            try
            {
                return _context.CustomerData.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody] CustomerDatum _customer)
        {
            if (_customer == null)
            {
                return BadRequest();
            }
            _customer.Id = new Guid().ToString();
            _context.CustomerData.Add(_customer);
            _context.SaveChanges();

            return new OkObjectResult(_customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] CustomerDatum _customer)
        {
            if (_customer == null || _customer.Id != id.ToString() )
            {
                return BadRequest();
            }

            var customer = _context.CustomerData.FirstOrDefault(t => t.Id == id.ToString());
            if (customer == null)
            {
                return NotFound();
            }

            customer.CustomerName = _customer.CustomerName;
            customer.ClassName = _customer.ClassName;
            customer.Email = _customer.Email;
            customer.Phone = _customer.Phone;
            customer.Comment = _customer.Comment;

            _context.CustomerData.Update(customer);
            _context.SaveChanges();
            return new OkObjectResult(_customer);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(List<CustomerDatum> customers)
        {

            _context.CustomerData.RemoveRange(customers);
          
            _context.SaveChanges();
            return Ok(  );
        }
    }

}
