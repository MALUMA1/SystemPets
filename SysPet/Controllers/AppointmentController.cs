using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SysPet.Data;
using SysPet.Models;
using System.Reflection;

namespace SysPet.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly DatingData data;
        private readonly PersonsData personsData;
        public AppointmentController()
        {
            data = new DatingData();
            personsData = new PersonsData();
        }
        // GET: AppointmentController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            return View( await data.GetAll());
        }

        // GET: AppointmentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await data.GetItem(id);
            return View(model);
        }
        
        public async Task<IActionResult> ShowDetails(int id)
        {
            var model = await data.GetItem(id);
            return PartialView("_ModalDetail", model);
        }

        // GET: AppointmentController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CitasViewModel();
            var persons = await personsData.GetAll();
            var personList = persons.Select(x => new SelectListItem
            {
                Value = x.IdPersona.ToString(),
                Text = $"{x.Nombre} {x.Apellidos}"
            }).ToList();

            model.Personas = personList;
            return View(model);
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CitasViewModel model)
        {
            try
            {
                var result = data.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var appointment = await data.GetItem(id);
            var states = await data.GetStates();
            var list = states.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            appointment.EstadoCitas = list;
            return View(appointment);
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CitasViewModel model)
        {
            try
            {
                var item = data.GetItem(id);
                if (item == null) { RedirectToAction(nameof(Index)); }

                if (model == null) { RedirectToAction(nameof(Index)); }

                if (!ModelState.IsValid) { RedirectToAction(nameof(Index)); }

                var result = data.Update(model, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
                return View();
            }
        }
    }
}
