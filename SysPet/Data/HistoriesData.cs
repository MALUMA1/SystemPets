using SysPet.Models;

namespace SysPet.Data
{
    public class HistoriesData : DataAccessBase<HistorialesViewModel>
    {
        public override int Create(HistorialesViewModel item)
        {
            var sql = $@"INSERT INTO Historiales VALUES (
                        '{FormatDate(item.FechaVisita)}', 
                        '{item.Motivo}', 
                        '{item.Diagnostico}', 
                         {item.IdPaciente})";

            return Execute(sql);
        }

        public override int Delete(int id)
        {
            var sql = $"DELETE FROM Historiales WHERE Id = @id;";

            return Execute(sql, new { id });
        }

        public async override Task<IEnumerable<HistorialesViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT h.[Id]
                              ,h.[FechaVisita]
                              ,h.[Motivo]
                              ,h.[Diagnostico]
                              ,p.[Nombre] Paciente
	                          ,ps.Nombre + ' ' + ps.Apellidos AS FullName
                          FROM [dbo].[Historiales] h
                          INNER JOIN Pacientes p on p.IdPaciente = h.IdPaciente
                          INNER JOIN Personas ps on ps.IdPersona = p.IdPersona";

                return await GetItems(sql);
            }
            catch (Exception)
            {
                return new List<HistorialesViewModel>();
            }
        }

        public async override Task<HistorialesViewModel> GetItem(int id)
        {
            var sql = @$"SELECT h.[Id]
                              ,h.[FechaVisita]
                              ,h.[Motivo]
                              ,h.[Diagnostico]
                              ,p.[Nombre] Paciente
	                          ,ps.Nombre + ' ' + ps.Apellidos AS FullName
                          FROM [dbo].[Historiales] h
                          INNER JOIN Pacientes p on p.IdPaciente = h.IdPaciente
                          INNER JOIN Personas ps on ps.IdPersona = p.IdPersona
                          WHERE h.[Id] = @id";

            return await Get(sql, new { id });
        }

        public override int Update(HistorialesViewModel item, int id)
        {
            var date = item.FechaVisita.Date.Year < DateTime.Now.Year ? DateTime.Now.Date : item.FechaVisita.Date;
            var sql = $@"UPDATE Historiales SET
                        FechaVisita='{FormatDate(date)}', 
                        Motivo='{item.Motivo}', 
                        Diagnostico='{item.Diagnostico}'
                        WHERE [Id] = @id";

            return Execute(sql, new { id });
        }
    }
}
