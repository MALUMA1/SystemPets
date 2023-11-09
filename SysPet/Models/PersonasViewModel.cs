using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SysPet.Models
{
    public class PersonasViewModel
    {
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(100, MinimumLength =3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres.")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres.")]
        [DisplayName("Appellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 100 caracteres.")]
        [DisplayName("Appellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo debe tener entre 3 y 25 caracteres.")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Este campo debe contener solo letras.")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo debe tener entre 3 y 25 caracteres.")]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [DisplayName("Código Postal")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos numéricos.")]
        public int CodigoPostal { get; set; }
        [DisplayName("Teléfono")]
        [StringLength(10)]
        public string Telefono { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos numéricos.")]
        public int PhoneNumber { get; set; }
        public bool Estado { get; set; }
        public int IdTipoPersona { get; set; }
        public List<MascotasViewModel> Mascotas { get; set; }
        public UsuariosViewModel Usuario { get; set; }
    }
}
