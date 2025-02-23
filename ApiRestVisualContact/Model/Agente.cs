using ApiRestVisualContact.enums;

namespace ApiRestVisualContact.Model
{
    public class Agente
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Estados estado { get; set; }
        public DateTime fecha { get; set; }
    }
}
