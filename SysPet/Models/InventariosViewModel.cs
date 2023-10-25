using System.ComponentModel;

namespace SysPet.Models
{
    public class InventariosViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        [DisplayName("Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

    }
}
