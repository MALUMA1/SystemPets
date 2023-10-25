using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPet.Data;
using SysPet.Models;

namespace SysPet.Controllers
{
    public class InternmentController : Controller
    {
        private readonly InternmentsData data;
        public InternmentController()
        {
            data = new InternmentsData();
        }

        // GET: InternmentController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            return View();
        }

        // GET: InternmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InternmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InternmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InternamientosViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InternmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InternmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InternamientosViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InternmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InternmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InternamientosViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
