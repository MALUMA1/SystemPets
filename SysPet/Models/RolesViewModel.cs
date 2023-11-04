using System.ComponentModel.DataAnnotations;

namespace SysPet.Models
{
    public class RolesViewModel
    {
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 50 caracteres.")]
        public string Nombre { get; set; }
    }
}
