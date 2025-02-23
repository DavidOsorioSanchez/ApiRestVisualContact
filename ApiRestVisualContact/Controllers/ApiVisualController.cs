using ApiRestVisualContact.Migrations;
using ApiRestVisualContact.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace ApiRestVisualContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVisualController : ControllerBase, IApiVisualController
    {

        private readonly VisualContactDBContext _dbContext;

        public ApiVisualController (VisualContactDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet]
        public async Task<ActionResult<List<Agente>>> GetAllAgentes()
        {
            return Ok(await _dbContext.agentesdb.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Agente>> GetAgenteByID(long Id)
        {
            
            var agente = await _dbContext.agentesdb.FindAsync(Id);
            if (agente is null)
                return NotFound();

            return Ok(agente);
        }

        [HttpPost]
        public async Task<ActionResult<Agente>> AddAgente(Agente newAgente)
        {
            if (newAgente is null)
                return BadRequest();

            _dbContext.agentesdb.Add(newAgente);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAgenteByID), new { Id = newAgente.Id }, newAgente);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAgente(long Id, Agente AgenteActual)
        {
            
            var agente = await _dbContext.agentesdb.FindAsync(Id);
            if (agente is null)
                return NotFound();

            agente.Nombre = AgenteActual.Nombre;
            agente.estado = AgenteActual.estado;
            agente.fecha = AgenteActual.fecha;

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAgente(long Id)
        {
            
            var agente = await _dbContext.agentesdb.FindAsync(Id);
            if (agente is null)
                return NotFound();

            _dbContext.agentesdb.Remove(agente);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
