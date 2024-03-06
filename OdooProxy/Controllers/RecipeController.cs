using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;
using Microsoft.Extensions.Logging; // Add logging

namespace OdooProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipesContext _context;
        private readonly ILogger<RecipeController> _logger; // Logger

        public RecipeController(RecipesContext context, ILogger<RecipeController> logger) // Inject logger
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Recipe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        // GET: api/Recipe/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Recipe>> GetRecipe(long id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                _logger.LogInformation($"Recipe with ID {id} not found."); // Logging
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutRecipe(long id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest("Recipe ID mismatch.");
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "An error occurred while updating the recipe."); // Log error
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recipe
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteRecipe(long id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeExists(long id) => _context.Recipes.Any(e => e.Id == id);
    }
}
