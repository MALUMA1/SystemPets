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

                var headers = result.Select(x => new SalesViewModel
                {
                    Id = x.Id,
                    FechaVenta = x.FechaVenta,
                    TotalArticulos = x.TotalArticulos,
                    TotalSale = x.TotalSale,
                }).GroupBy(x => new { x.Id, x.FechaVenta, x.TotalArticulos, x.TotalSale}).ToList();

                var details = result.Select(x => new SalesDetailViewModel
                {
                    IdVenta = x.Id,
                    Articulo = x.Articulo,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio,
                    Cantidad = x.Cantidad,
                    TotalItem = x.TotalItem,
                    Imagen = x.Imagen,
                    TipoContenido = x.TipoContenido,
                }).Distinct().GroupBy(x => new { x.IdVenta }).ToList();

                var finalList = headers.Join(details, h => h.Key.Id, d => d.Key.IdVenta, (h, d) => new SalesViewModel
                {
                    Id = h.Key.Id,
                    FechaVenta = h.Key.FechaVenta,
                    TotalArticulos = h.Key.TotalArticulos,
                    TotalSale = h.Key.TotalSale,
                    DetalleVenta = d.Select(x => x).ToList()
                });

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
                            TotalItem = item.TotalItem
                        });
                    }

                    model.DetalleVenta.AddRange(list);

                    salesList.Add(model);
                }
                
                return View(finalList);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<ActionResult> SalesDetail(int id)
        {
            try
            {
                var result = await salesData.GetAll();

                var list = result.Where(x => x.Id == id).ToList();

                var headers = list.Select(x => new SalesViewModel
                {
                    Id = x.Id,
                    FechaVenta = x.FechaVenta,
                    TotalArticulos = x.TotalArticulos,
                    TotalSale = x.TotalSale,
                }).GroupBy(x => new { x.Id, x.FechaVenta, x.TotalArticulos, x.TotalSale }).ToList();

                var details = list.Select(x => new SalesDetailViewModel
                {
                    IdVenta = x.Id,
                    Articulo = x.Articulo,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio,
                    Cantidad = x.Cantidad,
                    TotalItem = x.TotalItem,
                    Imagen = x.Imagen,
                    TipoContenido = x.TipoContenido,
                }).Distinct().GroupBy(x => new { x.IdVenta }).ToList();

                var finalModel = headers.Join(details, h => h.Key.Id, d => d.Key.IdVenta, (h, d) => new SalesViewModel
                {
                    Id = h.Key.Id,
                    FechaVenta = h.Key.FechaVenta,
                    TotalArticulos = h.Key.TotalArticulos,
                    TotalSale = h.Key.TotalSale,
                    DetalleVenta = d.Select(x => x).ToList()
                }).FirstOrDefault();

                return View(finalModel);
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
                    Precio = x.PrecioSugerido,
                    Stok = x.Stock,
                    Producto = x.Nombre
                }).ToList();

                var detalles = model.DetalleVenta;
                var finalList = detalles.Join(list, d => d.IdProducto, l => l.IdProducto, (d, l) => new SalesDetailViewModel
                {
                    IdProducto = d.IdProducto,
                    Cantidad = d.Cantidad,
                    Descripcion = l.Descripcion,
                    Precio = l.Precio,
                    Stok = l.Stok,
                    Producto = l.Producto,
                });

                var validateStock = finalList.Where(x => x.Cantidad > x.Stok).ToList();
                if (validateStock.Any())
                {
                    foreach (var item in validateStock)
                    {
                        ModelState.AddModelError(string.Empty, $"El artículo {item.Producto} no cuenta con sufuciente existencia, Existencia: {item.Stok}");
                    }
                    model.Productos = products.Select(x => new SelectListItem
                    {
                        Value = x.IdProducto.ToString(),
                        Text = x.Nombre
                    }).ToList();

                    model.ListaProductos = products.ToList();

                    return View(model);
                }

                var productsToUpdate = finalList.Where(x => idProducts.Contains(x.IdProducto)).Select(x => new ProductosViewModel
                {
                    IdProducto = x.IdProducto,
                    Stock = x.StokToUpdate
                }).ToList();

                var updated = productsData.UpdateStock(productsToUpdate);

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
