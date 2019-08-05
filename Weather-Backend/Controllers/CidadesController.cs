using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weather_Backend.Models;

namespace Weather_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly CidadeContext _context;

        public CidadesController(CidadeContext context)
        {
            _context = context;
        }

        // GET: api/Cidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> GetCidades()
        {
            var cidades = await _context.Cidades.ToListAsync();

            return cidades;
        }

        // GET: api/Cidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetCidade(long id)
        {
            var cidade = await _context.Cidades.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // PUT: api/Cidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade(long id, Cidade cidade)
        {
            if (id != cidade.Id)
            {
                return BadRequest();
            }

            _context.Entry(cidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
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

        // POST: api/Cidades
        [HttpPost]
        public async Task<ActionResult<Cidade>> PostCidade(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidade", new { id = cidade.Id }, cidade);
        }

        // DELETE: api/Cidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cidade>> DeleteCidade(long id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();

            return cidade;
        }

        private bool CidadeExists(long id)
        {
            return _context.Cidades.Any(e => e.Id == id);
        }
    }
}
