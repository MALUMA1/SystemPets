using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace SysPet.Models
{
    public class InternamientosViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; } = DateTime.Now.Date;
        public string Medicamento { get; set; }
        public string Antecedentes { get; set; }
        public string Tratamiento { get; set; }
        public bool Estado { get; set; }
        public int IdPaciente { get; set; }
        public int IdPersona { get; set; }
        public int IdDoctor { get; set; }
        public string Paciente { get; set; }
        public string Propietario { get; set; }
        [DisplayName("Atendió")]
        public string Atendio { get; set; }
        public string FullName { get; set;}

        public List<SelectListItem> Personas { get; set; }
        public List<SelectListItem> Pacientes { get; set; }
        public List<SelectListItem> Doctores { get; set; }
    }
}
