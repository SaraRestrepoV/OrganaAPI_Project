using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organa.DAL;
using Organa.DAL.Entities;

namespace Organa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public IngredientController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync(); // Select * From ingredients

            if (ingredients == null) return NotFound();

            return ingredients;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Chef>> GetIngredientsById(Guid? id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(c => c.Id == id); // Select * From Ingredients where...

            if (ingredient == null) return NotFound();

            return Ok(ingredient);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateIngredient")]
        public async Task<ActionResult> CreateIngredient(Ingredient ingredient)
        {
            try
            {
                ingredient.Id = Guid.NewGuid();
                ingredient.CreatedDate = DateTime.Now;
                ingredient.ModifiedDate = null;

                _context.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Ingredient '{0}' already exists!", ingredient.Name));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ingredient);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditCountry(Guid? idIngredient, Ingredient ingredient)
        {
            try
            {
                if (idIngredient != ingredient.Id) return NotFound("Ingredient not found!");

                ingredient.ModifiedDate = DateTime.Now;

                _context.Ingredients.Update(ingredient);
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("Ingredient '{0}' already exists!", ingredient.Id));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ingredient);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteIngredients(Guid? id)
        {
            if (_context.Ingredients == null) return Problem("Entity set 'DataBaseContext.Ingredients' is null.");
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(c => c.Id == id);

            if (ingredient == null) return NotFound("Ingredient not found");

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("Ingredient '{0}' was deleted!", ingredient.Name));
        }
    }
}
