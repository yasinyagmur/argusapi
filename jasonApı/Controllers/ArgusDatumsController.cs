using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jasonApı.Models;

namespace jasonApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArgusDatumsController : ControllerBase
    {
        private readonly ArgusContext _context;

        public ArgusDatumsController(ArgusContext context)
        {
            _context = context;
        }

        // GET: api/ArgusDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArgusDatum>>> GetArgusData()
        {
          if (_context.ArgusData == null)
          {
              return NotFound();
          }
            return await _context.ArgusData.ToListAsync();
        }

        // GET: api/ArgusDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArgusDatum>> GetArgusDatum(int id)
        {
          if (_context.ArgusData == null)
          {
              return NotFound();
          }
            var argusDatum = await _context.ArgusData.FindAsync(id);

            if (argusDatum == null)
            {
                return NotFound();
            }

            return argusDatum;
        }

        // PUT: api/ArgusDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArgusDatum(int id, ArgusDatum argusDatum)
        {
            if (id != argusDatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(argusDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArgusDatumExists(id))
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

        // POST: api/ArgusDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArgusDatum>> PostArgusDatum(ArgusDatum argusDatum)
        {
          if (_context.ArgusData == null)
          {
              return Problem("Entity set 'ArgusContext.ArgusData'  is null.");
          }
            _context.ArgusData.Add(argusDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArgusDatum", new { id = argusDatum.Id }, argusDatum);
        }

        // DELETE: api/ArgusDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArgusDatum(int id)
        {
            if (_context.ArgusData == null)
            {
                return NotFound();
            }
            var argusDatum = await _context.ArgusData.FindAsync(id);
            if (argusDatum == null)
            {
                return NotFound();
            }

            _context.ArgusData.Remove(argusDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArgusDatumExists(int id)
        {
            return (_context.ArgusData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
