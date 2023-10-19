namespace SysPet.Models
{
    public class ProductosViewModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Proveedor { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioSugerido { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Estado { get; set; }
    }
}
