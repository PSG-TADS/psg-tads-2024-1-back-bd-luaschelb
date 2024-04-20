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
    public class FeedbacksController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public FeedbacksController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedbacks>>> GetFeedbacks()
        {
            try
            {
                return await _context.Feedbacks.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar feedbacks");
            }
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedbacks>> GetFeedbacks(int id)
        {
            try
            {
                var feedbacks = await _context.Feedbacks.FindAsync(id);

                if (feedbacks == null)
                {
                    return NotFound();
                }

                return feedbacks;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar feedback");
            }
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbacks(int id, Feedbacks feedbacks)
        {
            try
            {
                if (id != feedbacks.Id)
                {
                    return BadRequest();
                }

                _context.Entry(feedbacks).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbacksExists(id))
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
                return StatusCode(500, "Ocorreu um erro ao editar feedback");
            }
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feedbacks>> PostFeedbacks(Feedbacks feedbacks)
        {
            try
            {
                _context.Feedbacks.Add(feedbacks);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFeedbacks", new { id = feedbacks.Id }, feedbacks);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao criar feedback");
            }
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbacks(int id)
        {
            try
            {
                var feedbacks = await _context.Feedbacks.FindAsync(id);
                if (feedbacks == null)
                {
                    return NotFound();
                }

                _context.Feedbacks.Remove(feedbacks);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao deletar feedback");
            }
        }

        private bool FeedbacksExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
