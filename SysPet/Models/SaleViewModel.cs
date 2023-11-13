namespace SysPet.Models
{
    public class SaleViewModel
    {
        public string Id { get; set; }
        public string Fecha { get; set; }
        public string Articulos { get; set; }
        public string TotalVenta { get; set; }
        public string IVA { get; set; } = "0";
        public List<DetailViewModel> DetalleVenta { get; set; }
    }
    public class DetailViewModel
    {
        public string Producto { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }
        public string TotalItem { get; set; }
    }
}
