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
    public class OcorrenciasController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public OcorrenciasController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Ocorrencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocorrencias>>> GetOcorrencias()
        {
            return await _context.Ocorrencias.ToListAsync();
        }

        // GET: api/Ocorrencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ocorrencias>> GetOcorrencias(int id)
        {
            var ocorrencias = await _context.Ocorrencias.FindAsync(id);

            if (ocorrencias == null)
            {
                return NotFound();
            }

            return ocorrencias;
        }

        // PUT: api/Ocorrencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcorrencias(int id, Ocorrencias ocorrencias)
        {
            if (id != ocorrencias.Id)
            {
                return BadRequest();
            }

            _context.Entry(ocorrencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcorrenciasExists(id))
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

        // POST: api/Ocorrencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ocorrencias>> PostOcorrencias(Ocorrencias ocorrencias)
        {
            _context.Ocorrencias.Add(ocorrencias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcorrencias", new { id = ocorrencias.Id }, ocorrencias);
        }

        // DELETE: api/Ocorrencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOcorrencias(int id)
        {
            var ocorrencias = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencias == null)
            {
                return NotFound();
            }

            _context.Ocorrencias.Remove(ocorrencias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OcorrenciasExists(int id)
        {
            return _context.Ocorrencias.Any(e => e.Id == id);
        }
    }
}
