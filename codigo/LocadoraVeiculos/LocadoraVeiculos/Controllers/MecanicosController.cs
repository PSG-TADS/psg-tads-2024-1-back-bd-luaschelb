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
            try
            {
                return await _context.Mecanicos.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar mecanicos");
            }
        }

        // GET: api/Mecanicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanicos>> GetMecanicos(int id)
        {
            try
            {
                var mecanicos = await _context.Mecanicos.FindAsync(id);

                if (mecanicos == null)
                {
                    return NotFound();
                }

                return mecanicos;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar mecanico");
            }
        }

        // PUT: api/Mecanicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanicos(int id, Mecanicos mecanicos)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao editar mecanico");
            }
        }

        // POST: api/Mecanicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mecanicos>> PostMecanicos(Mecanicos mecanicos)
        {
            try
            {
                _context.Mecanicos.Add(mecanicos);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMecanicos", new { id = mecanicos.Id }, mecanicos);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar mecanico");
            }
        }

        // DELETE: api/Mecanicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecanicos(int id)
        {
            try
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
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao deletar mecanico");
            }
        }

        private bool MecanicosExists(int id)
        {
            return _context.Mecanicos.Any(e => e.Id == id);
        }
    }
}
