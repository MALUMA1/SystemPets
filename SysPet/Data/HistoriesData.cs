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
                var sql = @$"SELECT [Id]
                              ,[FechaVisita]
                              ,[Motivo]
                              ,[Diagnostico]
                              ,[IdPaciente]
                          FROM [dbo].[Historiales]";

                return await GetItems(sql);
            }
            catch (Exception)
            {
                return new List<HistorialesViewModel>();
            }
        }

        public async override Task<HistorialesViewModel> GetItem(int id)
        {
            var sql = @$"SELECT [Id]
                              ,[FechaVisita]
                              ,[Motivo]
                              ,[Diagnostico]
                              ,[IdPaciente]
                          FROM [dbo].[Historiales]
                          WHERE [Id] = @id";

            return await Get(sql, new { id });
        }

        public override int Update(HistorialesViewModel item, int id)
        {
            var sql = $@"UPDATE Historiales SET
                        '{FormatDate(item.FechaVisita)}', 
                        '{item.Motivo}', 
                        '{item.Diagnostico}'
                        WHERE [Id] = @id";

            return Execute(sql, new { id });
        }
    }
}
