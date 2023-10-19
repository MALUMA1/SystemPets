namespace SysPet.Models
{
    public class PacientesViewModel
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Edad { get; set; }
        public string Color { get; set; }
        public string Peso { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
