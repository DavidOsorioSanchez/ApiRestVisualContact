using ApiRestVisualContact.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestVisualContact.service
{
    public interface ICliente
    {
        Task<ActionResult<Cliente>> AddCliente(Cliente newCliente);
        Task<IActionResult> DeleteCliente(long Id);
        Task<ActionResult<Cliente>> GetClienteByID(long Id);
        Task<ActionResult<List<Cliente>>> GetAllCliente();
        Task<IActionResult> UpdateCliente(long Id, Cliente ClienteActual);
    }
}
