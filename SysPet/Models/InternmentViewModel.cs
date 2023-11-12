namespace SysPet.Models
{
    public class InternmentViewModel
    {
        public string Id { get; set; }
        public string Propietario { get; set; }
        public string Atendio { get; set; }
        public string Fecha { get; set; }
        public string Medicamento { get; set; }
        public string Antecedentes { get; set; }
        public string Tratamiento { get; set; }
        public string Paciente { get; set; }
        public byte[] Imagen { get; set; }
        public string TipoContenido { get; set; }
    }
}
