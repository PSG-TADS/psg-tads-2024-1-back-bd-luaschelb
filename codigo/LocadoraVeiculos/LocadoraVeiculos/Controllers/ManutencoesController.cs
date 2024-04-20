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
    public class ManutencoesController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public ManutencoesController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Manutencoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manutencoes>>> GetManutencoes()
        {
            try
            {
                return await _context.Manutencoes.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar manutencoes");
            }
        }

        // GET: api/Manutencoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manutencoes>> GetManutencoes(int id)
        {
            try
            {
                var manutencoes = await _context.Manutencoes.FindAsync(id);

                if (manutencoes == null)
                {
                    return NotFound();
                }

                return manutencoes;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar manutencao");
            }
        }

        // PUT: api/Manutencoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManutencoes(int id, Manutencoes manutencoes)
        {
            try
            {
                if (id != manutencoes.Id)
                {
                    return BadRequest();
                }

                _context.Entry(manutencoes).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManutencoesExists(id))
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
                return StatusCode(500, "Ocorreu um erro ao editar manutencao");
            }
        }

        // POST: api/Manutencoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manutencoes>> PostManutencoes(Manutencoes manutencoes)
        {
            try
            {
                _context.Manutencoes.Add(manutencoes);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetManutencoes", new { id = manutencoes.Id }, manutencoes);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar manutencao");
            }
        }

        // DELETE: api/Manutencoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManutencoes(int id)
        {
            try
            {
                var manutencoes = await _context.Manutencoes.FindAsync(id);
                if (manutencoes == null)
                {
                    return NotFound();
                }

                _context.Manutencoes.Remove(manutencoes);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao deletar manutencao");
            }
        }

        private bool ManutencoesExists(int id)
        {
            return _context.Manutencoes.Any(e => e.Id == id);
        }
    }
}
