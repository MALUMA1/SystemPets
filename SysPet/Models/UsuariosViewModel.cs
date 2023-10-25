using System.ComponentModel;

namespace SysPet.Models
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        [DisplayName("Contraseña")]
        public string Contrasenia { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public bool Estado { get; set; }
    }
}
