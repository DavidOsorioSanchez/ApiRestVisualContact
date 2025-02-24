using ApiRestVisualContact.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestVisualContact.service
{
    public interface IAgente
    {
        Task<ActionResult<Agente>> AddAgente(Agente newAgente);
        Task<IActionResult> DeleteAgente(long Id);
        Task<ActionResult<Agente>> GetAgenteByID(long Id);
        Task<ActionResult<List<Agente>>> GetAllAgentes();
        Task<IActionResult> UpdateAgente(long Id, Agente AgenteActual);
    }
}