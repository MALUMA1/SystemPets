using SysPet.Models;

namespace SysPet.Data
{
    public class PersonsData : DataAccessBase<PersonasViewModel>
    {
        public override int Create(PersonasViewModel item)
        {
            var sql = $@"INSERT INTO Personas VALUES('{item.Nombre}','{item.ApellidoPaterno} {item.ApellidoMaterno}','{item.Direccion}','{item.Ciudad}','{item.CodigoPostal}','{item.Telefono}',1,{item.IdTipoPersona},'{item.ApellidoPaterno}', '{item.ApellidoMaterno}')";

            return Execute(sql);
        }

        public override int Delete(int id)
        {
            var sql = $"DELETE FROM Personas WHERE IdPersona = @id;";

            return Execute(sql, new { id });
        }

        public async override Task<IEnumerable<PersonasViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT [IdPersona]
                              ,[Nombre]
                              ,[Apellidos]
                              ,[ApellidoPaterno]
                              ,[ApellidoMaterno]
                              ,[Direccion]
                              ,[Cuidad] Ciudad
                              ,[CodigoPostal]
                              ,[Telefono]
                              ,[Estado]
                          FROM [dbo].[Personas]
                          WHERE IdTipoPersona=2";

                return await GetItems(sql);
            }
            catch
            {
                return new List<PersonasViewModel>();
            }
        }

        public async Task<IEnumerable<PersonasViewModel>> GetAll(int idTipoPersona)
        {
            try
            {
                var sql = @$"SELECT [IdPersona]
                              ,[Nombre]
                              ,[Apellidos]
                              ,[ApellidoPaterno]
                              ,[ApellidoMaterno]
                              ,[Direccion]
                              ,[Cuidad] Ciudad
                              ,[CodigoPostal]
                              ,[Telefono]
                              ,[Estado]
                          FROM [dbo].[Personas]
                          WHERE IdTipoPersona=@idTipoPersona";

                return await GetItems(sql, new { idTipoPersona });
            }
            catch
            {
                return new List<PersonasViewModel>();
            }
        }

        public async override Task<PersonasViewModel> GetItem(int id)
        {
            var sql = @$"SELECT [IdPersona]
                              ,[Nombre]
                              ,[Apellidos]
                              ,[ApellidoPaterno]
                              ,[ApellidoMaterno]
                              ,[Direccion]
                              ,[Cuidad] Ciudad
                              ,[CodigoPostal]
                              ,[Telefono]
                              ,[Estado]
                          FROM [dbo].[Personas]
                          WHERE IdPersona = @id";

            return await Get(sql, new { id });
        }

        public override int Update(PersonasViewModel item, int id)
        {
            var sql = $@"UPDATE Personas SET Nombre='{item.Nombre}',
                                ApellidoPaterno='{item.ApellidoPaterno}',
                                ApellidoMaterno='{item.ApellidoMaterno}',
                                Direccion='{item.Direccion}',
                                Cuidad='{item.Ciudad}',
                                CodigoPostal='{item.CodigoPostal}',
                                Telefono='{item.Telefono}',
                                Estado={GetEstado(item.Estado)}
                                WHERE IdPersona = @id";

            return Execute(sql, new { id });
        }
    }
}
