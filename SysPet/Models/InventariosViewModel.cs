using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace SysPet.Models
{
    public class InventariosViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; } = DateTime.Now.Date;
        [DisplayName("Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; } = DateTime.Now.Date;
        public int Stock { get; set; }
        public bool Estado { get; set; }
        [DisplayName("Estado")]
        public string State { get { return Estado ? "Activo" : "Inactivo"; } }
        public int IdProducto { get; set; }
        [DisplayName("Nombre del artículo")]
        public string Producto { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public List<SelectListItem> Productos { get; set; }

    }
}
