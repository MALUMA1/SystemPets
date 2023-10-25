using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPet.Data;
using SysPet.Models;
using System.Reflection;

namespace SysPet.Controllers
{
    public class PatientController : Controller
    {
        private readonly PetsData data;
        public PatientController()
        {
            data = new PetsData();
        }

        // GET: PatientController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            return View(await data.GetAll());
        }

        // GET: PatientController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await data.GetItem(id));
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MascotasViewModel model)
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

        // GET: PatientController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MascotasViewModel model)
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

        // GET: PatientController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MascotasViewModel model)
        {
            try
            {
                if (model == null) { RedirectToAction(nameof(Index)); }
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
