using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace SysPet.Models
{
    public class SalesDetailViewModel
    {
        public int Id { get; set; }
        [DisplayName("Venta No.")]
        public int IdVenta { get; set; }
        public string Descripcion { get; set; }
        
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get { return Precio * Cantidad; } }
        [DisplayName("Total")]
        public decimal TotalItem { get; set; }
        [DisplayName("Artículo")]
        public int IdProducto { get; set; }
        [DisplayName("Artículo")]
        public string Articulo { get; set; }
        public byte[] Imagen { get; set; }
        public string TipoContenido { get; set; }
        public List<SelectListItem> Productos { get; set; }

        public int Stok { get; set; }
        public string Producto { get; set; }
        public int StokToUpdate { get { return Stok > 0 ? (Stok - (int)Cantidad) : Stok; } }
    }
}
