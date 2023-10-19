namespace SysPet.Models
{
    public class HistorialesViewModel
    {
        public int Id { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Motivo { get; set; }
        public string Diagnostico { get; set; }
        public int IdPaciente { get; set; }
    }
}
