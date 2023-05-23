using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organa.DAL;
using Organa.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Organa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CustomerController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            var costumers = await _context.Customers.ToListAsync(); // Select * From Countries

            if (costumers == null) return NotFound();

            return costumers;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(String id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.customerId == id); //Select * From Customer Where Id = "..."

            if (customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateCustomer")]
        public async Task<ActionResult> CreateCustomer(Customer customer)
        {
            try
            {
                customer.CreatedDate = DateTime.Now;
                customer.ModifiedDate = null;

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Customer identified with the document number '{0}' already exists!", customer.customerId));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(customer);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditCustomer(string customerId, Customer customer)
        {
            try
            {
                if (customerId != customer.customerId) return NotFound("Customer not found!");

                customer.ModifiedDate = DateTime.Now;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Customer identified with the document number '{0}' already exists!", customer.customerId));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(customer);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteCustomer(string id)
        {
            if (_context.Customers == null) return Problem("Entity set 'DataBaseContext.Customer' is null.");
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.customerId == id);

            if (customer == null) return NotFound("Customer not found!");

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(); 

            return Ok(String.Format("Customer '{0} {1}' was deleted!", customer.firstName, customer.lastName));
        }
    }
}
