namespace SysPet.Models
{
    public class InventariosViewModel
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
        public int IdProducto { get; set; }
    }
}
