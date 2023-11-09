using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPet.Data;
using SysPet.Exception;
using SysPet.Models;
using System.Reflection;

namespace SysPet.Controllers
{
    [ServiceFilter(typeof(ManageExceptionFilter))]
    public class PersonController : Controller
    {
        private readonly PersonsData data;
        private readonly CostumerDetailData costumerDetailData;
        public PersonController()
        {
            data = new PersonsData();
            costumerDetailData = new CostumerDetailData();
        }

        // GET: PersonController
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

        // GET: PersonController/Details/5
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

        public async Task<ActionResult> CostumerDetail(int id)
        {
            try
            {
                return View(await costumerDetailData.GetCostumerDetail(id));
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonasViewModel model)
        {
            try
            {
                model.IdTipoPersona = 2;
                model.Telefono = model.PhoneNumber.ToString();
                var result = data.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: PersonController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await data.GetItem(id));
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonasViewModel model)
        {
            try
            {
                id = id > 0 ? id : model.IdPersona;
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
