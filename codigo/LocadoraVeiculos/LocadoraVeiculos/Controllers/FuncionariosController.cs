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
    public class FuncionariosController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public FuncionariosController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionarios>>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionarios>> GetFuncionarios(int id)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(id);

            if (funcionarios == null)
            {
                return NotFound();
            }

            return funcionarios;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionarios(int id, Funcionarios funcionarios)
        {
            if (id != funcionarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcionarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionariosExists(id))
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

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcionarios>> PostFuncionarios(Funcionarios funcionarios)
        {
            _context.Funcionarios.Add(funcionarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionarios", new { id = funcionarios.Id }, funcionarios);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionarios(int id)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionariosExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
