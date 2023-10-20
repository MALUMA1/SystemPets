using Dapper;
using SysPet.Models;
using System.Data.SqlClient;

namespace SysPet.Data
{
    public class ProductsData
    {
        private readonly SqlConnection connection;
        private readonly string connectionString;

        public ProductsData()
        {
            
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            connection = new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<ProductosViewModel>> GetProducts()
        {
            try
            {
                var sql = @$"SELECT [IdProducto],[Nombre],[FechaIngreso],[Proveedor],[Cantidad],[Stock],[PrecioUnitario],[PrecioSugerido],[Descripcion],[FechaVencimiento],[Estado]
                        FROM [dbo].[Productos]";

                connection.Open();
                var productos = await connection.QueryAsync<ProductosViewModel>(sql);
                connection.Close();
                return productos;
            }
            catch (Exception ex)
            {
                return new List<ProductosViewModel>();
            }
            
        }

        public async Task<ProductosViewModel> GetProduct(int idProducto)
        {
            var sql = @$"SELECT [IdProducto],[Nombre],[FechaIngreso],[Proveedor],[Cantidad],[Stock],[PrecioUnitario],[PrecioSugerido],[Descripcion],[FechaVencimiento],
                                [Estado]  FROM [Pets].[dbo].[Productos] WHERE idProducto = @idProducto";
            connection.Open();
            var producto = await connection.QuerySingleAsync<ProductosViewModel>(sql, new { idProducto });
            connection.Close();
            return producto;
        }

        public int CreateProduct(ProductosViewModel producto)
        {
            var sql = @$"INSERT INTO Productos (Nombre, FechaIngreso, Proveedor, Cantidad, Stock, PrecioUnitario, PrecioSugerido, Descripcion, FechaVencimiento, Estado)
            VALUES ('${producto.Nombre}', '${FormatDate(producto.FechaIngreso)}', '${producto.Proveedor}', ${producto.Cantidad}, ${producto.Stock}, 
                    ${producto.PrecioUnitario}, ${producto.PrecioSugerido}, '${producto.Descripcion}', '${FormatDate(producto.FechaVencimiento)}', 1);";
            connection.Open();
            var result = connection.Execute(sql);
            connection.Close();

            return result;
        }

        public int UpdateProduct(ProductosViewModel producto, int idProducto)
        {
            var estado = producto.Estado ? 1 : 0;
            var sql = @$"UPDATE Productos SET Nombre='{producto.Nombre}',
                                Cantidad={producto.Cantidad}, 
                                Stock={producto.Stock},
                                PrecioUnitario={producto.PrecioUnitario},
                                PrecioSugerido={producto.PrecioSugerido},
                                Descripcion='{producto.Descripcion}',
                                FechaVencimiento='{FormatDate(producto.FechaVencimiento)}',
                                Estado={estado }
                        WHERE idProducto = @idProducto";
            connection.Open();
            var result = connection.Execute(sql, new { idProducto });
            connection.Close();

            return result;
        }

        public int DeleteProduct(int idProducto)
        {
            var sql = $"DELETE FROM Productos WHERE IdProducto = @idProducto;";
            connection.Open();
            var result = connection.Execute(sql, new { idProducto});
            connection.Close();

            return result;
        }

        private string FormatDate(DateTime date)
        {
            return $"{date.Year}-{date.Month}-{date.Day}";
        }
    }
}
