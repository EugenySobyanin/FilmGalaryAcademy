using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmGallaryAPI;

namespace FilmGallaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Film2Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Film2Controller(DataContext context)
        {
            _context = context;
        }

        // GET: api/Film2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film2>>> GetFilms()
        {
            return await _context.Films.ToListAsync();
        }

        // GET: api/Film2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film2>> GetFilm2(int id)
        {
            var film2 = await _context.Films.FindAsync(id);

            if (film2 == null)
            {
                return NotFound();
            }

            return film2;
        }

        // PUT: api/Film2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm2(int id, Film2 film2)
        {
            if (id != film2.Id)
            {
                return BadRequest();
            }

            _context.Entry(film2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Film2Exists(id))
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

        // POST: api/Film2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film2>> PostFilm2(Film2 film2)
        {
            _context.Films.Add(film2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm2", new { id = film2.Id }, film2);
        }

        // DELETE: api/Film2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm2(int id)
        {
            var film2 = await _context.Films.FindAsync(id);
            if (film2 == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Film2Exists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
