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
    public class DeliveryPersonController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public DeliveryPersonController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<DeliveryPerson>>> GetDeliveryPersons()
        {
            var distributors = await _context.Distributors.ToListAsync(); // Select * From DeliveryMan

            if (distributors == null) return NotFound();

            return distributors;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<DeliveryPerson>> GetDistributorsById(String id)
        {
            var deliveryPerson = await _context.Distributors.FirstOrDefaultAsync(c => c.deliveryPersonId == id); // Select * From DeliveryMan where...

            if (deliveryPerson == null) return NotFound();

            return Ok(deliveryPerson);
        }


        [HttpPost, ActionName("Create")]
        [Route("CreateDeliveryPerson")]
        public async Task<ActionResult> CreateDeliveryPerson(DeliveryPerson deliveryPerson)
        {
            try
            {
                deliveryPerson.CreatedDate = DateTime.Now;
                deliveryPerson.ModifiedDate = null;

                _context.Distributors.Add(deliveryPerson);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Insert Into...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Delivery person identified with the document number '{0}' already exists!", deliveryPerson.deliveryPersonId));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(deliveryPerson);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditCustomer(string deliveryPersonId, DeliveryPerson deliveryPerson)
        {
            try
            {
                if (deliveryPersonId != deliveryPerson.deliveryPersonId) return NotFound("Delivery person not found");

                deliveryPerson.ModifiedDate = DateTime.Now;

                _context.Distributors.Update(deliveryPerson);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Delivery person identified with the document number '{0}' already exists!", deliveryPerson.deliveryPersonId));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(deliveryPerson);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteDeliveryPerson(string id)
        {
            if (_context.Distributors == null) return Problem("Entity set 'DataBaseContext.DeliveryPerson' is null.");
            var deliveryPerson = await _context.Distributors.FirstOrDefaultAsync(c => c.deliveryPersonId == id);

            if (deliveryPerson == null) return NotFound("DeliveryMan not found");

            _context.Distributors.Remove(deliveryPerson);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("Delivery person '{0} {1}' was deleted!", deliveryPerson.firstName, deliveryPerson.lastName));
        }

    }
}
