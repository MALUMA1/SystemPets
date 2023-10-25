using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPet.Data;
using SysPet.Models;
using System.Reflection;

namespace SysPet.Controllers
{
    public class HistoryController : Controller
    {
        private readonly HistoriesData data;
        public HistoryController() 
        {
            data = new HistoriesData();
        }

        // GET: HistoryController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            return View(await data.GetAll());
        }

        // GET: HistoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await data.GetItem(id));
        }

        // GET: HistoryController/Create
        public ActionResult Create()
        {
            return View();
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
                return View();
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

        // GET: HistoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View( await data.GetItem(id));
        }

        // POST: HistoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, HistorialesViewModel model)
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
