using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocadoraVeiculos.Models;

namespace LocadoraVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicosController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public MecanicosController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Mecanicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mecanicos>>> GetMecanicos()
        {
            return await _context.Mecanicos.ToListAsync();
        }

        // GET: api/Mecanicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanicos>> GetMecanicos(int id)
        {
            var mecanicos = await _context.Mecanicos.FindAsync(id);

            if (mecanicos == null)
            {
                return NotFound();
            }

            return mecanicos;
        }

        // PUT: api/Mecanicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanicos(int id, Mecanicos mecanicos)
        {
            if (id != mecanicos.Id)
            {
                return BadRequest();
            }

            _context.Entry(mecanicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MecanicosExists(id))
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

        // POST: api/Mecanicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mecanicos>> PostMecanicos(Mecanicos mecanicos)
        {
            _context.Mecanicos.Add(mecanicos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMecanicos", new { id = mecanicos.Id }, mecanicos);
        }

        // DELETE: api/Mecanicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecanicos(int id)
        {
            var mecanicos = await _context.Mecanicos.FindAsync(id);
            if (mecanicos == null)
            {
                return NotFound();
            }

            _context.Mecanicos.Remove(mecanicos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MecanicosExists(int id)
        {
            return _context.Mecanicos.Any(e => e.Id == id);
        }
    }
}
