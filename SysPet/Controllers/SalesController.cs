using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SysPet.Data;
using SysPet.Exception;
using SysPet.Models;
using System.Reflection;

namespace SysPet.Controllers
{
    [ServiceFilter(typeof(ManageExceptionFilter))]
    public class SalesController : Controller
    {
        private readonly SalesData salesData;
        private readonly ProductsData productsData;

        public SalesController()
        {
            salesData = new SalesData();
            productsData = new ProductsData();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Url = "Shared/EmptyData";

                var model = new SalesViewModel();
                var list = new List<SalesDetailViewModel>();
                var salesList = new List<SalesViewModel>();

				ViewBag.Url = "Shared/EmptyData";
                var result = await salesData.GetAll();

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        model.Id = item.Id;
                        model.FechaVenta = item.FechaVenta;
                        model.TotalArticulos = item.TotalArticulos;
                        model.TotalSale = item.TotalSale;
                        list.Add(new SalesDetailViewModel
                        {
                            IdVenta = model.Id,
                            Articulo = item.Articulo,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            Cantidad = item.Cantidad,
                            TotalItem = item.Total
                        });
                    }

                    model.DetalleVenta.AddRange(list);

                    salesList.Add(model);
                }
                
                return View(salesList);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<ActionResult> Preview(SalesViewModel model)
        {
            try
            {
                var list = await productsData.GetAll();
                var productIdList = model.DetalleVenta.Select(x => x.IdProducto).ToList();
                var finalList = list.Where(x => productIdList.Contains(x.IdProducto)).ToList();
                ViewBag.Url = "Shared/EmptyData";
                return View();
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            var model = new SalesViewModel();
            var products = await productsData.GetAll();
            model.ListaProductos = products.ToList();
            model.Productos = products.Select(x => new SelectListItem
            {
                Value = x.IdProducto.ToString(),
                Text = x.Nombre
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SalesViewModel model)
        {
            try
            {
                var products = await productsData.GetAll();

                var idProducts = model.DetalleVenta.Select(x => x.IdProducto).ToList();
                var list = products.Where(x => idProducts.Contains(x.IdProducto)).Select(x => new SalesDetailViewModel
                {
                    IdProducto = x.IdProducto,
                    Descripcion = x.Descripcion,
                    Precio = x.PrecioSugerido
                }).ToList();

                var detalles = model.DetalleVenta;
                var finalList = detalles.Join(list, d => d.IdProducto, l => l.IdProducto, (d, l) => new SalesDetailViewModel
                {
                    IdProducto = d.IdProducto,
                    Cantidad = d.Cantidad,
                    Descripcion = l.Descripcion,
                    Precio = l.Precio,
                });

                model.DetalleVenta = finalList.ToList();

                var result = salesData.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var sale = await salesData.GetItem(id);
            var products = await productsData.GetAll();
            sale.Productos = products.Select(x => new SelectListItem
            {
                Value = x.IdProducto.ToString(),
                Text = x.Nombre
            }).ToList();
            return View(sale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SalesViewModel model)
        {
            try
            {
                var result = salesData.Update(model, id);
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
                var result = salesData.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
