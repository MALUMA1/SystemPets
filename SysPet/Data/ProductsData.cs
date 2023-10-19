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
            connection = new SqlConnection();
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        public async Task<List<ProductosViewModel>> GetProducts()
        {
            var sql = "Select * FROM Productos";
            var productos = await connection.QueryAsync<ProductosViewModel>(sql);

            return productos.ToList();
        }

        public async Task<List<ProductosViewModel>> GetProducts(int idProducto)
        {
            var sql = "Select * FROM Productos WHERE idProducto = @idProducto";
            var productos = await connection.QueryAsync<ProductosViewModel>(sql, new { idProducto });

            return productos.ToList();
        }

        public int CreateProduct(ProductosViewModel producto)
        {
            var sql = @$"INSERT INTO Productos (Nombre, FechaIngreso, Proveedor, Cantidad, Stock, PrecioUnitario, PrecioSugerido, Descripcion, FechaVencimiento, Estado)
            VALUES ('${producto.Nombre}', '${producto.FechaIngreso}', '${producto.Proveedor}', ${producto.Cantidad}, ${producto.Stock}, 
                    ${producto.PrecioUnitario}, ${producto.PrecioSugerido}, '${producto.Descripcion}', '${producto.FechaVencimiento}', 1);";
            var result = connection.Execute(sql);

            return result;
        }

        public int DeleteProduct(int idProducto)
        {
            var sql = $"DELETE FROM Productos WHERE IdProducto = @idProducto;";
            var result = connection.Execute(sql, new { idProducto});

            return result;
        }

    }
}
