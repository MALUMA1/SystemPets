using SysPet.Models;

namespace SysPet.Data
{
    public class InventoriesData : DataAccessBase<InventariosViewModel>
    {
        public override int Create(InventariosViewModel item)
        {
            var sql = @$"INSERT INTO Inventarios values (
                        '{FormatDate(item.FechaIngreso)}',
                        '{FormatDate(item.FechaVencimiento)}',
                        {item.Stock},
                        1,
                        {item.IdProducto})";

            return Execute(sql);
        }

        public override int Delete(int id)
        {
            var sql = $"DELETE FROM Inventarios WHERE Id = @id;";

            return Execute(sql, new { id });
        }

        public async override Task<IEnumerable<InventariosViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT i.[Id]
                              ,i.[FechaIngreso]
                              ,i.[FechaVencimiento]
                              ,i.[Stock]
                              ,i.[Estado]
                              ,p.[Nombre] Producto
	                          ,p.[Descripcion]
                          FROM [dbo].[Inventarios] i
                          INNER JOIN [dbo].[Productos] p on i.IdProducto = p.IdProducto";

                return await GetItems(sql);
            }
            catch (Exception)
            {
                return new List<InventariosViewModel>();
            }
        }

        public async override Task<InventariosViewModel> GetItem(int id)
        {
            var sql = @$"SELECT i.[Id]
                              ,i.[FechaIngreso]
                              ,i.[FechaVencimiento]
                              ,i.[Stock]
                              ,i.[Estado]
                              ,p.[Nombre] Producto
	                          ,p.[Descripcion]
                          FROM [dbo].[Inventarios] i
                          INNER JOIN [dbo].[Productos] p on i.IdProducto = p.IdProducto
                          WHERE [Id] = @id";

            return await Get(sql, new { id });
        }

        public override int Update(InventariosViewModel item, int id)
        {
            var sql = @$"UPDATE Inventarios SET
                        '{FormatDate(item.FechaIngreso)}',
                        '{FormatDate(item.FechaVencimiento)}',
                        {item.Stock},
                        {GetEstado(item.Estado)}";

            return Execute(sql, new { id });
        }
    }
}
