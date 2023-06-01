using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organa.DAL;
using Organa.DAL.Entities;
using DbUpdateException = Microsoft.EntityFrameworkCore.DbUpdateException;
using System.Diagnostics.Metrics;

namespace Organa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public OrderController(DataBaseContext context)
        {
            _context = context;
        }

        /*[HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Chef>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync(); 

            if (orders == null) return NotFound("Order not found!");

            return orders;
        }*/

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Chef>> GetOrderById(Guid? id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateOrder")]
        public async Task<ActionResult> CreateOrder(Chef chef)
        {
            try
            {
                
                chef.CreatedDate = DateTime.Now;
                chef.ModifiedDate = null;

                _context.Chefs.Add(chef);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Insert Into...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Chef identified with the document number '{0}' already exists!", chef.idChef));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(chef);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditCountry(string idChef, Chef chef)
        {
            try
            {
                if (idChef != chef.idChef) return NotFound("Chef not found!");

                chef.ModifiedDate = DateTime.Now;

                _context.Chefs.Update(chef);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Chef identified with the document number '{0}' already exists!", chef.idChef));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(chef);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteChef(string id)
        {
            if (_context.Chefs == null) return Problem("Entity set 'DataBaseContext.Chefs' is null.");
            var chef = await _context.Chefs.FirstOrDefaultAsync(c => c.idChef == id);

            if (chef == null) return NotFound("Chef not found!");

            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("Chef '{0} {1}' was deleted!", chef.firstNameChef, chef.lastNameChef));
        }


    }
}
