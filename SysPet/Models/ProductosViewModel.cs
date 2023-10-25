using System.ComponentModel;

namespace SysPet.Models
{
    public class ProductosViewModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        public string Proveedor { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        [DisplayName("Precio Unitario")]
        public decimal PrecioUnitario { get; set; }
        [DisplayName("Precio Sugerido")]
        public decimal PrecioSugerido { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }
        public bool Estado { get; set; }
    }
}
