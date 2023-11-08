using SysPet.Models;

namespace SysPet.Data
{
    public class SalesData : DataAccessBase<SalesViewModel>
    {
        public override int Create(SalesViewModel item)
        {
            var sql = $@"INSERT INTO Ventas VALUES('{FormatDate(item.FechaVenta)}',{item.CantidadArticulos}, {item.Total}) SELECT CAST(SCOPE_IDENTITY() as int)";
            var result = ExecuteWithId(sql);

            foreach (var detalle in item.DetalleVenta)
            {
                detalle.IdVenta = result;
                var query = $@"INSERT INTO DetalleVenta VALUES({detalle.IdVenta},'{detalle.Descripcion}', {detalle.Cantidad}, {detalle.Precio}, {detalle.Total}, {detalle.IdProducto})";
                Execute(query);
            }

            return result;
        }

        public override int Delete(int id)
        {
            var query = $"DELETE FROM DetalleVenta WHERE IdVenta = @id;";
            Execute(query, new { id });

            var sql = $"DELETE FROM Ventas WHERE Id = @id;";

            return Execute(sql, new { id });
        }

        public async override Task<IEnumerable<SalesViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT v.[Id]
                              ,v.[FechaVenta]
                              ,v.[CantidadArticulos] TotalArticulos
                              ,v.[Total] As TotalSale
	                          ,d.[Descripcion]
                              ,d.[Precio]
                              ,d.[Cantidad]
                              ,d.[Total] TotalItem
	                          ,p.Nombre Articulo
                          FROM [dbo].[Ventas] v
                          INNER JOIN [dbo].[DetalleVenta] d on d.IdVenta = v.Id
                          INNER JOIN [dbo].[Productos] p on p.IdProducto = d.IdProducto";

                return await GetItems(sql);
            }
            catch
            {
                return new List<SalesViewModel>();
            }
        }

        public async override Task<SalesViewModel> GetItem(int id)
        {
            var sql = @$"SELECT v.[Id]
                              ,v.[FechaVenta]
                              ,v.[CantidadArticulos]
                              ,v.[Total] As TotalSale
	                          ,d.[Descripcion]
                              ,d.[Precio]
                              ,d.[Cantidad]
                              ,d.[Total]
	                          ,p.Nombre Articulo
                          FROM [dbo].[Ventas] v
                          INNER JOIN [dbo].[DetalleVenta] d on d.IdVenta = v.Id
                          INNER JOIN [dbo].[Productos] p on p.IdProducto = d.IdProducto
                          WHERE v.[Id] = @id";

            return await Get(sql, new { id });
        }

        public override int Update(SalesViewModel item, int id)
        {
            //var sql = $@"UPDATE Ventas SET 
            //            Descripcion={item.Descripcion},
            //            FechaVenta={item.FechaVenta},
            //            Cantidad={item.Cantidad},
            //            Precio={item.Precio},
            //            Total={item.Total}
            //            WHERE [Id] = @id";

            return Execute("", new { id });
        }
    }
}
