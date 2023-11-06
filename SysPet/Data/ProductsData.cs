using Dapper;
using SysPet.Models;

namespace SysPet.Data
{
    public class ProductsData : DataAccessBase<ProductosViewModel>
    {

        public ProductsData()
        {
        }

        public override async Task<IEnumerable<ProductosViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT [IdProducto],[Nombre],[FechaIngreso],[Proveedor],[Cantidad],[Stock],[PrecioUnitario],[PrecioSugerido],[Descripcion],[FechaVencimiento],[Estado]
                        FROM [dbo].[Productos]";

                return await GetItems(sql);
            }
            catch
            {
                return new List<ProductosViewModel>();
            }
            
        }

        public override async Task<ProductosViewModel> GetItem(int idProducto)
        {
            var sql = @$"SELECT [IdProducto],[Nombre],[FechaIngreso],[Proveedor],[Cantidad],[Stock],[PrecioUnitario],[PrecioSugerido],[Descripcion],[FechaVencimiento],
                                [Estado]  FROM [Pets].[dbo].[Productos] WHERE idProducto = @idProducto";

            return await Get(sql, new { idProducto });
        }

        public override int Create(ProductosViewModel producto)
        {
            var sql = @$"INSERT INTO Productos 
                        (Nombre, FechaIngreso, Proveedor, Cantidad, Stock, PrecioUnitario, PrecioSugerido, Descripcion, FechaVencimiento, Estado)
            VALUES ('{producto.Nombre}', 
                    '{FormatDate(producto.FechaIngreso)}', 
                    '{producto.Proveedor}', 
                    {producto.Cantidad}, 
                    {producto.Stock}, 
                    {producto.PrecioUnitario}, 
                    {producto.PrecioSugerido}, 
                   '{producto.Descripcion}', 
                   '{FormatDate(producto.FechaVencimiento)}', 
                    1);";

            return Execute(sql);
        }

        public override int Update(ProductosViewModel producto, int idProducto)
        {
            var sql = @$"UPDATE Productos SET Nombre='{producto.Nombre}',
                                Cantidad={producto.Cantidad}, 
                                Stock={producto.Stock},
                                PrecioUnitario={producto.PrecioUnitario},
                                PrecioSugerido={producto.PrecioSugerido},
                                Descripcion='{producto.Descripcion}',
                                FechaVencimiento='{FormatDate(producto.FechaVencimiento)}',
                                Estado={GetEstado(producto.Estado)}
                        WHERE idProducto = @idProducto";

            return Execute(sql, new { idProducto });
        }

        public override int Delete(int idProducto)
        {
            var sql = $"DELETE FROM Productos WHERE IdProducto = @idProducto;";

            return Execute(sql, new { idProducto});
        }

    }
}
