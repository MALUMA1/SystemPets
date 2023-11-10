using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SysPet.Data;
using SysPet.Models;

using DinkToPdf;
using DinkToPdf.Contracts;
using SysPet.Exception;
using Rotativa.AspNetCore;
using SysPet.Services;

namespace SysPet.Controllers
{
    [ServiceFilter(typeof(ManageExceptionFilter))]
    public class InternmentController : Controller
    {
        private readonly InternmentsData data;
        private readonly PersonsData personsData;
        private readonly PetsData petsData;
        private readonly IConverter converter;
        private readonly IPdfService<InternamientosViewModel> _pdfService;
        public InternmentController(IConverter converter, IPdfService<InternamientosViewModel> pdfService)
        {
            data = new InternmentsData();
            personsData = new PersonsData();
            petsData = new PetsData();
            this.converter = converter;
            _pdfService = pdfService;
        }

        public IActionResult ShowPdf()
        {
            string currentPage = HttpContext.Request.Path;
            string pageUrl = HttpContext.Request.GetEncodedUrl();

            pageUrl = pageUrl.Replace(currentPage, "");
            pageUrl = $"{pageUrl}/Internment/Details";

            var pdfSettings = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = { new ObjectSettings
                {
                    Page = pageUrl
                } }
            };

            var pdf = converter.Convert(pdfSettings);

            return File(pdf,"application/pdf");
        }

        public async Task<IActionResult> DownloadPdf(InternamientosViewModel model)
        {
            try
            {
                var item = await data.GetItem(model.Id);

                var pdfBytes = _pdfService.GeneratePdf(new List<InternamientosViewModel> { item});

                string pdfName = $"Detalle_Internamiento_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.pdf";

                return File(pdfBytes, "application/pdf", pdfName);

            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> DownloadIndexPdf()
        {
            try
            {
                var items = await data.GetAll();

                var pdfBytes = _pdfService.GeneratePdf(items);

                string pdfName = $"Internamientos_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.pdf";

                return File(pdfBytes, "application/pdf", pdfName);

            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        // GET: InternmentController
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Url = "Shared/EmptyData";
                return View(await data.GetAll());

            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<ActionResult> PDF(int id)
        {
            try
            {
                return View(await data.GetItem(id));
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: InternmentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                return View(await data.GetItem(id));

            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: InternmentController/Create
        public async Task<ActionResult> Create()
        {
            try

            {

                var model = new InternamientosViewModel();
                var persons = await personsData.GetAll(2);
                var doctors = await personsData.GetAll(3);
                var patients = await petsData.GetAll();

                var personList = persons.Select(x => new SelectListItem
                {
                    Value = x.IdPersona.ToString(),
                    Text = $"{x.Nombre} {x.ApellidoPaterno} {x.ApellidoMaterno}"
                }).ToList();

                var doctorList = doctors.Select(x => new SelectListItem
                {
                    Value = x.IdPersona.ToString(),
                    Text = $"{x.Nombre} {x.ApellidoPaterno} {x.ApellidoMaterno}"
                }).ToList();

                var patientList = patients.Select(x => new SelectListItem
                {
                    Value = x.IdPaciente.ToString(),
                    Text = $"{x.Nombre}"
                }).ToList();

                model.Personas = personList;
                model.Pacientes = patientList;
                model.Doctores = doctorList;
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: InternmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InternamientosViewModel model)
        {
            try
            {
                var resut = data.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: InternmentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: InternmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InternamientosViewModel model)
        {
            try
            {
                id = id > 0 ? id : model.Id;
                var item = data.GetItem(id);
                if (item == null) { RedirectToAction(nameof(Index)); }

                var result = data.Update(model, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0) { RedirectToAction(nameof(Index)); }
                var result = data.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
