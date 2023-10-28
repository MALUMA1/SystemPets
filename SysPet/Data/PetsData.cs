using SysPet.Models;

namespace SysPet.Data
{
    public class PetsData : DataAccessBase<MascotasViewModel>
    {
        public override int Create(MascotasViewModel item)
        {
            var sql = $@"INSERT INTO Pacientes VALUES(
                        '{item.Nombre}',
                        '{item.Raza}',
                        '{item.Especie}',
                        '{item.Sexo}',
                        {item.Edad},
                        '{item.Color}',
                        '{item.Peso}', 
                        1, GETDATE(),{item.IdPersona})";

            return Execute(sql);
        }

        public override int Delete(int id)
        {
            var sql = $"DELETE FROM Pacientes WHERE IdPaciente = @id;";

            return Execute(sql, new { id });
        }

        public async override Task<IEnumerable<MascotasViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT p.[IdPaciente]
                              ,p.[Nombre]
                              ,p.[Raza]
                              ,p.[Especie]
                              ,p.[Sexo]
                              ,p.[Edad]
                              ,p.[Color]
                              ,p.[Peso]
                              ,p.[Estado]
                              ,p.[Fecha]
                              ,a.Nombre Propietario
	                          ,a.Apellidos
                          FROM [dbo].[Pacientes] p
                          INNER JOIN [dbo].[Personas] a on a.IdPersona = p.IdPersona";

                return await GetItems(sql);
            }
            catch (Exception)
            {
                return new List<MascotasViewModel>();
            }
        }

        public async override Task<MascotasViewModel> GetItem(int id)
        {
            var sql = @$"SELECT p.[IdPaciente]
                              ,p.[Nombre]
                              ,p.[Raza]
                              ,p.[Especie]
                              ,p.[Sexo]
                              ,p.[Edad]
                              ,p.[Color]
                              ,p.[Peso]
                              ,p.[Estado]
                              ,p.[Fecha]
                              ,a.Nombre Propietario
	                          ,a.Apellidos
                          FROM [dbo].[Pacientes] p
                          INNER JOIN [dbo].[Personas] a on a.IdPersona = p.IdPersona
                          WHERE p.IdPaciente = @id";

            return await Get(sql, new { id });
        }

        public override int Update(MascotasViewModel item, int id)
        {
            var sql = $@"UPDATE Pacientes SET
                        Nombre='{item.Nombre}',
                        Raza='{item.Raza}',
                        Especie='{item.Especie}',
                        Sexo='{item.Sexo}',
                        Edad={item.Edad},
                        Color='{item.Color}',
                        Peso='{item.Peso}', 
                        Estado={GetEstado(item.Estado)}
                        WHERE IdPaciente = @id";

            return Execute(sql, new { id });
        }
    }
}
