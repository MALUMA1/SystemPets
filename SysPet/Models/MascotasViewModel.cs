using System.ComponentModel;

namespace SysPet.Models
{
    public class MascotasViewModel
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Edad { get; set; }
        public string Color { get; set; }
        public string Peso { get; set; }
        public bool Estado { get; set; }

        [DisplayName("Fecha de Registro")]
        public DateTime Fecha { get; set; }
        public int IdPersona { get; set; }
    }
}
