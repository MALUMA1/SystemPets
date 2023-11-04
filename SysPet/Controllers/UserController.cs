using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SysPet.Data;
using SysPet.Models;
using System.Net.Http;
using System.Reflection;

namespace SysPet.Controllers
{
    public class UserController : Controller
    {
        

        private readonly UsersData _usersData;
        public UserController()
        {
            _usersData = new UsersData();
        }

        [HttpGet]
        public IActionResult Singin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Singin(UsuariosViewModel model)
        {

            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Contrasenia))
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
            }
            else
            {
                var user = await _usersData.GetUserManager(model.Email, model.Contrasenia);
                if (user != null && model.Email == user.Email && model.Contrasenia == user.Contrasenia)
                {
                    return RedirectToAction("Index", "Home"); // Redirige al usuario a la página de inicio después de iniciar sesión.
                }
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(UsuariosViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Contrasenia))
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
            }
            else
            {
                var user = await _usersData.GetUserManager(model.Email, model.Contrasenia);
                if (user == null || model.Email != user.Email || model.Contrasenia != user.Contrasenia)
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                }

                HttpContext.Session.SetString("User", user.Nombre);
                HttpContext.Session.SetInt32("UserId", user.Id);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            ViewBag.Url = "Shared/EmptyData";
            return View(await _usersData.GetAll());
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _usersData.GetItem(id));
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            var model = new UsuariosViewModel();

            var roles = await _usersData.GetRoles();
            var listRoles = roles.Select(x => new SelectListItem
            {
                Value = x.IdRol.ToString(),
                Text = x.Nombre
            }).ToList();

            model.Roles = listRoles;
            return View(model);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuariosViewModel model)
        {
            try
            {
                var result = _usersData.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UsuariosViewModel model)
        {
            try
            {
                if (model.Contrasenia != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Las contraseñas no coinciden");
                }

                model.IdRol = 2;
                var result = _usersData.Create(model);
                return RedirectToAction(nameof(LogIn));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _usersData.GetItem(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UsuariosViewModel model)
        {
            try
            {
                id = id > 0 ? id : model.Id;
                var product = await _usersData.GetItem(id);
                if (product == null) { RedirectToAction(nameof(Index)); }

                if (model == null) { RedirectToAction(nameof(Index)); }

                if (!ModelState.IsValid) { RedirectToAction(nameof(Index)); }

                var result = _usersData.Update(model, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _usersData.GetItem(id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuariosViewModel model)
        {
            try
            {
                if (model == null) { RedirectToAction(nameof(Index)); }
                var result = _usersData.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
