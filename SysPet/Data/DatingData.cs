using SysPet.Models;

namespace SysPet.Data
{
    public class DatingData : DataAccessBase<CitasViewModel>
    {
        public override int Create(CitasViewModel item)
        {
            var sql = $@"";

            return Execute(sql);
        }

        public override int Delete(int id)
        {
            var sql = $"DELETE FROM Citas WHERE Id = @id;";

            return Execute(sql, new { id });
        }

        public async override Task<IEnumerable<CitasViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT [IdProducto],[Nombre],[FechaIngreso],[Proveedor],[Cantidad],[Stock],[PrecioUnitario],[PrecioSugerido],[Descripcion],[FechaVencimiento],[Estado]
                        FROM [dbo].[Productos]";

                return await GetItems(sql);
            }
            catch (Exception)
            {
                return new List<CitasViewModel>();
            }
        }

        public override Task<CitasViewModel> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(CitasViewModel item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
