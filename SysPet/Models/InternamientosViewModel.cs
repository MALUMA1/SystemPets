using System.ComponentModel;

namespace SysPet.Models
{
    public class InternamientosViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        public string Medicamento { get; set; }
        public string Antecedentes { get; set; }
        public string Tratamiento { get; set; }
        public bool Estado { get; set; }
        public int IdPaciente { get; set; }
        public int IdPersona { get; set; }
        public int IdPersonaDepartamento { get; set; }
    }
}
