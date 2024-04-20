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
    public class ReservasController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public ReservasController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservas>>> GetReservas()
        {
            try
            {
                return await _context.Reservas.ToListAsync();
            }
            catch (Exception ex) {
                return StatusCode(500, "Ocorreu um erro ao listar as reserva");
            }
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservas>> GetReservas(int id)
        {
            try
            {
                var reservas = await _context.Reservas.FindAsync(id);

                if (reservas == null)
                {
                    return NotFound();
                }

                return reservas;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar a reserva");
            }
        }

        // PUT: api/Reservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservas(int id, Reservas reservas)
        {
            try
            {
                if (id != reservas.Id)
                {
                    return BadRequest();
                }

                _context.Entry(reservas).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservasExists(id))
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
                return StatusCode(500, "Ocorreu um erro ao editar reserva");
            }
        }

        // POST: api/Reservas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservas>> PostReservas(Reservas reservas)
        {
            try
            {
                _context.Reservas.Add(reservas);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetReservas", new { id = reservas.Id }, reservas);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar reserva");
            }
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservas(int id)
        {
            try
            {
                var reservas = await _context.Reservas.FindAsync(id);
                if (reservas == null)
                {
                    return NotFound();
                }

                _context.Reservas.Remove(reservas);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao deletar reserva");
            }
        }

        private bool ReservasExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
