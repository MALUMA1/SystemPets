using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SysPet.Models
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo de Correo Electrónico es requerido.")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo de contraseña es requerido.")]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }
        [Required(ErrorMessage = "El campo es requerido.")]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar contraseña")]
        public string ConfirmPassword { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }
        public PersonasViewModel Persona { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
