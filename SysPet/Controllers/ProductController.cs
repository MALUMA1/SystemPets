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
            var products = await productsData.GetProducts();
            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await productsData.GetProduct(id);
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
                var result = productsData.CreateProduct(model);
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
            var product = await productsData.GetProduct(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, ProductosViewModel model)
        {
            try
            {
                var product = await productsData.GetProduct(id);
                if (product == null) { RedirectToAction(nameof(Index)); }

                if (model == null) { RedirectToAction(nameof(Index)); }

                if(!ModelState.IsValid) { RedirectToAction(nameof(Index));  }

                var result = productsData.UpdateProduct(model, id);
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await productsData.GetProduct(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductosViewModel model)
        {
            try
            {
                if (model == null) { RedirectToAction(nameof(Index)); }
                var result = productsData.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
