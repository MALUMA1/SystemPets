﻿using SysPet.Models;

namespace SysPet.Data
{
    public class InternmentsData : DataAccessBase<InternamientosViewModel>
    {
        public override int Create(InternamientosViewModel item)
        {
            var sql = $@"INSERT INTO Internamientos VALUES
                ('{FormatDate(item.FechaIngreso)}',
                '{item.Medicamento}',
                '{item.Antecedentes}',
                '{item.Tratamiento}',1,
                 {item.IdPaciente}, 
                 {item.IdPersona}, 
                 {item.IdDoctor})";

            return Execute(sql);
        }

        public override int Delete(int id)
        {
            var sql = $"DELETE FROM Internamientos WHERE Id = @id;";

            return Execute(sql, new { id });
        }

        public async override Task<IEnumerable<InternamientosViewModel>> GetAll()
        {
            try
            {
                var sql = @$"SELECT
                                I.[Id],
                                I.[FechaIngreso],
                                I.[Medicamento],
                                I.[Antecedentes],
                                I.[Tratamiento],
                                I.[Estado],
                                a.Nombre AS Paciente,
	                            I.IdPersona,
	                            I.IdDoctor
                            FROM [dbo].[Internamientos] I
                            INNER JOIN Pacientes a ON a.IdPaciente = I.IdPaciente";

                var internments =  await GetItems(sql);
                var persons = new List<InternamientosViewModel>();
                foreach (var item in internments)
                {
                    sql = @$"select IdPersona, Nombre + ' ' + Apellidos AS FullName from Personas where IdPersona in (@idPersona, @idDoctor)";

                    var result = await GetItems(sql, new { idPersona = item.IdPersona, idDoctor = item.IdDoctor });
                    foreach (var person in result)
                    {
                        if (item.IdPersona == person.IdPersona)
                        {
                            item.Propietario = person.FullName;
                        }
                        if (item.IdDoctor == person.IdPersona)
                        {
                            item.Atendio = person.FullName;
                        }
                    }
                    persons.AddRange(result);
                }

                return internments;

            }
            catch (Exception)
            {
                return new List<InternamientosViewModel>();
            }
        }

        public async override Task<InternamientosViewModel> GetItem(int id)
        {
            var sql = @$"SELECT
                                I.[Id],
                                I.[FechaIngreso],
                                I.[Medicamento],
                                I.[Antecedentes],
                                I.[Tratamiento],
                                I.[Estado],
                                a.Nombre AS Paciente,
	                            I.IdPersona,
	                            I.IdDoctor
                            FROM [dbo].[Internamientos] I
                            INNER JOIN Pacientes a ON a.IdPaciente = I.IdPaciente
                            WHERE I.Id = @id";

            var internments = await GetItems(sql, new { id });
            var persons = new List<InternamientosViewModel>();
            foreach (var item in internments ?? new List<InternamientosViewModel>())
            {
                sql = @$"select IdPersona, Nombre + ' ' + Apellidos AS FullName from Personas where IdPersona in (@idPersona, @idDoctor)";

                var result = await GetItems(sql, new { idPersona = item.IdPersona, idDoctor = item.IdDoctor });
                foreach (var person in result)
                {
                    if (item.IdPersona == person.IdPersona)
                    {
                        item.Propietario = person.FullName;
                    }
                    if (item.IdDoctor == person.IdPersona)
                    {
                        item.Atendio = person.FullName;
                    }
                }
                persons.AddRange(result);
            }

            var interment = internments?.Select(x => x).FirstOrDefault();

            return interment ?? new InternamientosViewModel();
        }

        public override int Update(InternamientosViewModel item, int id)
        {
            var sql = $@"UPDATE Internamientos SET
                        FechaIngreso='{FormatDate(item.FechaIngreso)}', 
                        Antecedentes='{item.Antecedentes}',
                        Medicamento='{item.Medicamento}', 
                        Antecedentes='{item.Antecedentes}',
                        Estado={GetEstado(item.Estado)}
                        WHERE [Id] = @id";

            return Execute(sql, new { id });
        }
    }
}