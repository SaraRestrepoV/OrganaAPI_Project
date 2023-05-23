using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organa.DAL;
using Organa.DAL.Entities;

namespace Organa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public InvoiceController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice()
        {
            var invoice = await _context.Invoices.ToListAsync(); // Select * From Invoice

            if (invoice == null) return NotFound();

            return invoice;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(Guid? id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(c => c.Id == id); // Select * From Invoice where...

            if (invoice == null) return NotFound();

            return Ok(invoice);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteInvoice(Guid? id)
        {
            if (_context.Invoices == null) return Problem("Entity set 'DataBaseContext.Invoice' is null.");
            var invoice = await _context.Invoices.FirstOrDefaultAsync(c => c.Id == id);

            if (invoice == null) return NotFound("Invoice not found");

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("la factura {0} fue eliminado!"));
        }
    }
}
