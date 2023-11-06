using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SysPet.Data;
using SysPet.Exception;
using SysPet.Models;

namespace SysPet.Controllers
{
    [ServiceFilter(typeof(ManageExceptionFilter))]
    public class HistoryController : Controller
    {
        private readonly HistoriesData data;
        private readonly PetsData petsData;
        public HistoryController() 
        {
            data = new HistoriesData();
            petsData = new PetsData();
        }

        // GET: HistoryController
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

        // GET: HistoryController/Details/5
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

        // GET: HistoryController/Create
        public async Task<ActionResult> Create()
        {
            var model = new HistorialesViewModel();
            var pacientes = await petsData.GetAll();
            var list = pacientes.Select(x => new SelectListItem
            {
                Value = x.IdPaciente.ToString(),
                Text = x.Nombre
            }).ToList();

            model.Pacientes = list;
            return View(model);
        }

        // POST: HistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistorialesViewModel model)
        {
            try
            {
                var result = data.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: HistoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: HistoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HistorialesViewModel model)
        {
            try
            {
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
