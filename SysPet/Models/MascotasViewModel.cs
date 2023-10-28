using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace SysPet.Models
{
    public class MascotasViewModel
    {
        public int IdPaciente { get; set; }
        [DisplayName("Paciente")]
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Edad { get; set; }
        public string Color { get; set; }
        public string Peso { get; set; }
        public bool Estado { get; set; }
        public string Propietario { get; set; }

        [DisplayName("Fecha de Registro")]
        public DateTime Fecha { get; set; }
        public int IdPersona { get; set; }
        public List<PersonasViewModel> Personas { get; set; }
        public List<SelectListItem> ListaPersonas { get; set; }
    }
}
