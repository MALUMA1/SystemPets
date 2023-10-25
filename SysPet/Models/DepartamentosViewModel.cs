using System.ComponentModel;

namespace SysPet.Models
{
    public class DepartamentosViewModel
    {
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        [DisplayName("Fecha de Registro")]
        public DateTime Fecha { get; set; }
    }
}
