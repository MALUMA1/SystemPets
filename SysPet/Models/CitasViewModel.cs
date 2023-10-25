using System.ComponentModel;

namespace SysPet.Models
{
    public class CitasViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Cita")]
        public DateTime FechaCita { get; set; }
        public string Motivo { get; set; }
        public int IdPersona { get; set; }
        public bool IdEstado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Estado { get; set; }
    }
}
