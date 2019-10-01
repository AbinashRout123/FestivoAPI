using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccessLayer;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestivoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly FestivoDBContext _context;
        
        public CategoriesController(FestivoDBContext context)
        {
            _context = context;
        }
        
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Categories> GetCategories()
        {
            return _context.categories;
        }
        
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var category = await _context.categories.FindAsync(id);
            
            if (category == null)
            {
                return NotFound();
            }
            
            return Ok(category);
        }
        
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] Categories category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            category.CategoryId = id;
            _context.Entry(category).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return NoContent();
        }
        
        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] Categories category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.categories.Add(category);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var category = await _context.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
            
            return Ok(category);
        }
        
        private bool CategoryExists(int id)
        {
            return _context.categories.Any(e => e.CategoryId == id);
        }
    }
}