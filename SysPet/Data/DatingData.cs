using SysPet.Models;

namespace SysPet.Data
{
    public class DatingData : DataAccessBase<CitasViewModel>
    {
        public override int Create(CitasViewModel item)
        {
            var sql = $@"INSERT INTO Citas values (
                        '{FormatDateTime(item.FechaCita)}', 
                        '{item.Motivo}', 
                          {item.IdPersona},
                           1)";

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
                var sql = @$"SELECT c.[Id],c.[FechaCita],c.[Motivo],p.[Nombre],p.[ApellidoPaterno],p.[ApellidoMaterno], e.[Nombre] Estado
                              FROM [dbo].[Citas] c
                              INNER JOIN [dbo].[Personas] p on p.IdPersona = c.IdPersona
                              INNER JOIN [dbo].[EstadoCitas] e on e.Id = c.IdEstado";

                return await GetItems(sql);
            }
            catch
            {
                return new List<CitasViewModel>();
            }
        }

        public async Task<IEnumerable<CitasViewModel>> GetStates()
        {
            try
            {
                var sql = @$"SELECT [Id],[Nombre] FROM [dbo].[EstadoCitas]";

                return await GetItems(sql);
            }
            catch
            {
                return new List<CitasViewModel>();
            }
        }

        public async override Task<CitasViewModel> GetItem(int id)
        {
            var sql = @$"SELECT c.[Id],c.[FechaCita],c.[Motivo],p.[Nombre],p.[ApellidoPaterno],p.[ApellidoMaterno], e.[Nombre] Estado
                          FROM [dbo].[Citas] c
                          INNER JOIN [dbo].[Personas] p on p.IdPersona = c.IdPersona
                          INNER JOIN [dbo].[EstadoCitas] e on e.Id = c.IdEstado
                          WHERE c.Id = @id";

            return await Get(sql, new { id });
        }

        public override int Update(CitasViewModel item, int id)
        {
            var sql = $@"UPDATE Citas SET
                        FechaCita='{FormatDateTime(item.FechaCita)}', 
                        Motivo='{item.Motivo}', 
                        IdEstado={item.IdEstado}
                        WHERE Id = @id";

            return Execute(sql, new { id });
        }
    }
}
