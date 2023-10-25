using Microsoft.AspNetCore.Mvc;
using SysPet.Data;
using SysPet.Models;

namespace SysPet.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentsData data;
        public DepartmentController()
        {
            data = new DepartmentsData();
        }

        // GET: DepartmentController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            return View(await data.GetAll());
        }

        // GET: DepartmentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await data.GetItem(id));
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartamentosViewModel model)
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

        // GET: DepartmentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DepartamentosViewModel model)
        {
            try
            {
                var item = await data.GetItem(id);
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

        // GET: DepartmentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DepartamentosViewModel model)
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
