using SysPet.Models;

namespace SysPet.Data
{
    public class InternmentsData : DataAccessBase<InternamientosViewModel>
    {
        public override int Create(InternamientosViewModel item)
        {
            var sql = $@"INSERT INTO Inventarios VALUES
                ('','','','',1,{item.IdPaciente}, {item.IdPersona}, {item.IdPersonaDepartamento})";

            return Execute(sql);
        }

        public override int Delete(int id)
        {
            var sql = $"DELETE FROM Internamientos WHERE Id = @id;";

            return Execute(sql, new { id });
        }

        public override Task<IEnumerable<InternamientosViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<InternamientosViewModel> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(InternamientosViewModel item, int id)
        {
            var sql = $@"UPDATE Internamientos SET
                        FechaIngreso='{FormatDate(item.FechaIngreso)}', 
                        Medicamento='{item.Medicamento}', 
                        Antecedentes='{item.Antecedentes}',
                        Estado={GetEstado(item.Estado)}
                        WHERE [Id] = @id";

            return Execute(sql, new { id });
        }
    }
}
