namespace SysPet.Models
{
    public class InternamientosViewModel
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Medicamento { get; set; }
        public string Antecedentes { get; set; }
        public string Tratamiento { get; set; }
        public bool Estado { get; set; }
        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        public int IdPersonaDepartamento { get; set; }
    }
}
