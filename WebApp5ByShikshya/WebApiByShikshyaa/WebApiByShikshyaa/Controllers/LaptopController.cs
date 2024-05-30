using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiByShikshyaa.Data;
using WebApiByShikshyaa.Models;

namespace WebApiByShikshyaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly LaptopDbContext _context;

        public LaptopsController(LaptopDbContext context)
        {
            _context = context;
        }

        // GET: api/Laptops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laptop>>> GetLaptops()
        {
            return await _context.Laptops.ToListAsync();
        }

        // GET: api/Laptops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laptop>> GetLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);

            if (laptop == null)
            {
                return NotFound();
            }

            return laptop;
        }

        // POST: api/Laptops
        [HttpPost]
        public async Task<ActionResult<Laptop>> PostLaptop([FromBody] Laptop laptop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // EF Core will automatically generate the Id
            _context.Laptops.Add(laptop);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LaptopExists(laptop.Id))
                {
                    return Conflict(new { message = "A laptop with the same ID already exists." });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetLaptop), new { id = laptop.Id }, laptop);
        }

        // PUT: api/Laptops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaptop(int id, [FromBody] Laptop laptop)
        {
            // Check if the id parameter matches the id property of the laptop object
            if (id != laptop.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            // Check if the laptop with the given id exists
            var existingLaptop = await _context.Laptops.FindAsync(id);
            if (existingLaptop == null)
            {
                return NotFound(new { message = "Laptop not found." });
            }

            // Update the existing laptop entity with the data from the request body
            existingLaptop.Brand = laptop.Brand;
            existingLaptop.Model = laptop.Model;
            existingLaptop.Price = laptop.Price;

            // Set the entity state to Modified so EF Core knows to update the entity in the database
            _context.Entry(existingLaptop).State = EntityState.Modified;

            try
            {
                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflicts if necessary
                if (!LaptopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Rethrow the exception if it's not a concurrency conflict
                }
            }

            return NoContent(); // Return 204 No Content on success
        }

        // DELETE: api/Laptops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }

            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(e => e.Id == id);
        }
    }
}
