using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organa.DAL;
using Organa.DAL.Entities;

namespace Organa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public MenuController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            var menu = await _context.Menus.ToListAsync(); // Select * From Menu

            if (menu == null) return NotFound();

            return menu;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Menu>> GetMenusById(Guid? id)
        {
            var menus = await _context.Menus.FirstOrDefaultAsync(c => c.Id == id); // Select * From Menu where...

            if (menus == null) return NotFound();

            return Ok(menus);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateMenu")]
        public async Task<ActionResult> CreateMenu(Menu menu)
        {
            try
            {
                menu.Id = Guid.NewGuid();
                menu.CreatedDate = DateTime.Now;
                menu.ModifiedDate = null;
                menu.Dishes = new List<Dish>();

                _context.Menus.Add(menu);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Menu identified with ID '{0}' already exists!", menu.Id));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(menu);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditCountry(Guid? idMenu, Menu menu)
        {
            try
            {
                if (idMenu != menu.Id) return NotFound("Menu not found!");

                menu.ModifiedDate = DateTime.Now;

                _context.Menus.Update(menu);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Menu identified with ID '{0}' already exists!", menu.Id));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(menu);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteMenu(Guid? id)
        {
            if (_context.Menus == null) return Problem("Entity set 'DataBaseContext.Menus' is null.");
            var menu = await _context.Menus.FirstOrDefaultAsync(c => c.Id == id);

            if (menu == null) return NotFound("Menu not found");

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("Menu identified with ID '{0}' was deleted!", menu.Id));
        }

    }
}
