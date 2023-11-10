using DinkToPdf;
using DinkToPdf.Contracts;
using SysPet.Models;
using System.Text;

namespace SysPet.Services
{
    public class PdfService : IPdfService<InternamientosViewModel>
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdf(IEnumerable<InternamientosViewModel> model)
        {
            var htmlContent = GenerateHtmlContent(model);

            var globalSettings = new GlobalSettings
            {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Landscape,
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "table.css"), PrintMediaType = true, Background = true},
                HeaderSettings = { FontSize = 9, Right = "Página [page] de [toPage]", Line = true, Center = "Internamientos", Spacing = 1 },
                FooterSettings = { FontSize = 9, Line = true, Center = "© SysPet " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), Spacing = 2, FontName = "Arial" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _converter.Convert(pdf);
        }

        private string GenerateHtmlContent(IEnumerable<InternamientosViewModel> data)
        {
            var sb = new StringBuilder();
            sb.Append("<table border='1' class='customTable'>");
            sb.Append("<tr><th>Id</th><th>Fecha de Ingreso</th><th>Medicamento</th><th>Tratamiento</th><th>Paciente</th><th>Propietario</th><th>Atendió</th></tr>");

            foreach (var item in data)
            {
                sb.Append($"<tr><td>{item.Id}</td><td>{item.FechaIngreso}</td><td>{item.Medicamento}</td><td>{item.Tratamiento}</td><td>{item.Paciente}</td><td>{item.Propietario}</td><td>{item.Atendio}</td></tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }
    }
}
