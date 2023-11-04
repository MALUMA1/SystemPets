using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SysPet.Models
{
    public class DepartamentosViewModel
    {
        public int IdDepartamento { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 20 caracteres.")]
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres.")]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        [DisplayName("Fecha de Registro")]
        public DateTime Fecha { get; set; }
    }
}
