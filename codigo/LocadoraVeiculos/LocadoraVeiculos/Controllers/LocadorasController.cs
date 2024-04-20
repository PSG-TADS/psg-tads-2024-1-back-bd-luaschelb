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
    public class LocadorasController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public LocadorasController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Locadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locadoras>>> GetLocadoras()
        {
            try
            {
                return await _context.Locadoras.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar locadoras");
            }
        }

        // GET: api/Locadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locadoras>> GetLocadoras(int id)
        {
            try
            {
                var locadoras = await _context.Locadoras.FindAsync(id);

                if (locadoras == null)
                {
                    return NotFound();
                }

                return locadoras;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar locadora");
            }
        }

        // PUT: api/Locadoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocadoras(int id, Locadoras locadoras)
        {
            try
            {
                if (id != locadoras.Id)
                {
                    return BadRequest();
                }

                _context.Entry(locadoras).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocadorasExists(id))
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
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao editar locadora");
            }
        }

        // POST: api/Locadoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locadoras>> PostLocadoras(Locadoras locadoras)
        {
            try
            {
                _context.Locadoras.Add(locadoras);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLocadoras", new { id = locadoras.Id }, locadoras);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar locadora");
            }
        }

        // DELETE: api/Locadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocadoras(int id)
        {
            try
            {
                var locadoras = await _context.Locadoras.FindAsync(id);
                if (locadoras == null)
                {
                    return NotFound();
                }

                _context.Locadoras.Remove(locadoras);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao deletar locadora");
            }
        }

        private bool LocadorasExists(int id)
        {
            return _context.Locadoras.Any(e => e.Id == id);
        }
    }
}
