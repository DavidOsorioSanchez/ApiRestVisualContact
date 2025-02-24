using ApiRestVisualContact.Migrations;
using ApiRestVisualContact.Model;
using ApiRestVisualContact.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestVisualContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase, ICliente
    {
        private readonly VisualContactDBContext _dbContext;

        public ClienteController(VisualContactDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        [HttpPost]
        public async Task<ActionResult<Cliente>> AddCliente(Cliente newClientes)
        {
            if (newClientes is null)
                return BadRequest();

            _dbContext.clientesdb.Add(newClientes);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClienteByID), new { Id = newClientes.Id }, newClientes);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCliente(long Id)
        {
            var cliente = await _dbContext.clientesdb.FindAsync(Id);
            if (cliente is null)
                return NotFound();

            _dbContext.clientesdb.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllCliente()
        {
            return Ok(await _dbContext.clientesdb.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Cliente>> GetClienteByID(long Id)
        {
            var cliente = await _dbContext.clientesdb.FindAsync(Id);
            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCliente(long Id, Cliente ClienteActual)
        {
            var cliente = await _dbContext.clientesdb.FindAsync(Id);
            if (cliente is null)
                return NotFound();

            cliente.Nombre = ClienteActual.Nombre;
            cliente.fecha = ClienteActual.fecha;

            return NoContent();
        }
    }
}
