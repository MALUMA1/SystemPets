using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPet.Data;
using SysPet.Models;

namespace SysPet.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsData productsData;
        public ProductController()
        {
            productsData = new ProductsData();
        }

       
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            var products = await productsData.GetAll();
            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await productsData.GetItem(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductosViewModel model)
        {
            try
            {
                var result = productsData.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Update(int id)
        {
            var product = await productsData.GetItem(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, ProductosViewModel model)
        {
            try
            {
                id = id > 0 ? id : model.IdProducto;
                var product = await productsData.GetItem(id);
                if (product == null) { RedirectToAction(nameof(Index)); }

                if (model == null) { RedirectToAction(nameof(Index)); }

                if(!ModelState.IsValid) { RedirectToAction(nameof(Index));  }

                var result = productsData.Update(model, id);
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0) { RedirectToAction(nameof(Index)); }
                var result = productsData.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
