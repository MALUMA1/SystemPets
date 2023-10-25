using Microsoft.AspNetCore.Mvc;
using SysPet.Data;
using SysPet.Models;

namespace SysPet.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoriesData data;
        public InventoryController()
        {
            data = new InventoriesData();
        }

        // GET: InventoryController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            return View(await data.GetAll());
        }

        // GET: InventoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await data.GetItem(id));
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventariosViewModel model)
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

        // GET: InventoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventariosViewModel model)
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

        // GET: InventoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View( await data.GetItem(id));
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InventariosViewModel model)
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
