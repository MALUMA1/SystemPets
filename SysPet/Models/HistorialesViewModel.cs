using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace SysPet.Models
{
    public class HistorialesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Visita")]
        public DateTime FechaVisita { get; set; }
        public string Motivo { get; set; }
        [DisplayName("Diagnóstico")]
        public string Diagnostico { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        [DisplayName("Propietario")]
        public string FullName { get; set; }
        public List<SelectListItem> Pacientes { get; set; }
    }
}
