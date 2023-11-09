using System.ComponentModel;

namespace SysPet.Models
{
    public class CostumerDetailViewModel
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Nombre Completo")]
        public string FullName { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        [DisplayName("Código Postal")]
        public string CodigoPostal { get; set; }
        [DisplayName("Télefono")]
        public string Telefono { get; set; }
        [DisplayName("Estado")]
        public bool EstadoPersona { get; set; }
        [DisplayName("Estado")]
        public string Estado { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Paciente { get; set; }
        public string Color { get; set; }
        public string Raza { get; set; }
        public string Peso { get; set; }
        public string Sexo { get; set; }
        public byte[] Imagen { get; set; }
        public string TipoContenido { get; set; }
        public int IdCita { get; set; }
        [DisplayName("Fecha de Cita")]
        public DateTime FechaCita { get; set; } = DateTime.Now;
        public string Motivo { get; set; }
        [DisplayName("Estado")]
        public string EstadoCita { get; set; }
        public List<MascotasViewModel> Pacientes { get; set; }
        public List<CitasViewModel> Citas { get; set; }
    }
}
