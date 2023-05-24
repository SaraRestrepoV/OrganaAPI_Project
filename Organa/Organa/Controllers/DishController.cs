using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organa.DAL;
using Organa.DAL.Entities;

namespace Organa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public DishController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            var dishes = await _context.Dishes.ToListAsync(); // Select * From dish

            if (dishes == null) return NotFound();

            return dishes;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Dish>> GetDishesById(Guid? id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(c => c.Id == id); // Select * From Dish where...

            if (dish == null) return NotFound();

            return Ok(dish);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateDish")]
        public async Task<ActionResult> CreateDish(Dish dish)
        {
            try
            {
                dish.Id = Guid.NewGuid();
                dish.CreatedDate = DateTime.Now;
                dish.ModifiedDate = null;
                dish.Ingredients = new List<Ingredient>();

                _context.Dishes.Add(dish);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Dish '{0}' already exists!", dish.Name));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(dish);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditDish(Guid? id, Dish dish)
        {
            try
            {
                if (id != dish.Id) return NotFound("Plato no encontrado");

                dish.ModifiedDate = DateTime.Now;

                _context.Dishes.Update(dish);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Dish '{0}' already exists!", dish.Name));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(dish);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{Id}")]
        public async Task<ActionResult> DeleteDish(Guid? id)
        {
            if (_context.Dishes == null) return Problem("Entity set 'DataBaseContext.Dishes' is null.");

            var dish = await _context.Dishes.FirstOrDefaultAsync(c => c.Id == id);

            if (dish == null) return NotFound("Dish not found");

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("Dish '{0}' was deleted!", dish.Name));
        }

    }
}
