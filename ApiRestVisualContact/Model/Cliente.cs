using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestVisualContact.Model
{
    public class Cliente
    {
        //[Key]
        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime fecha { get; set; }

        //[ForeignKey("Agente")]
        //public int AgenteId { get; set; }
        //public Agente Agente { get; set; }
    }
}
