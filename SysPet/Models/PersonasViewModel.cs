using System.ComponentModel;

namespace SysPet.Models
{
    public class PersonasViewModel
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Ciudad { get; set; }
        [DisplayName("Código Postal")]
        public int CodigoPostal { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public int IdTipoPersona { get; set; }
        public List<MascotasViewModel> Mascotas { get; set; }
    }
}
