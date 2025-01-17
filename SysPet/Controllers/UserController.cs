﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SysPet.Data;
using SysPet.Exception;
using SysPet.Models;
using System.Security.Claims;

namespace SysPet.Controllers
{
    [ServiceFilter(typeof(ManageExceptionFilter))]
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
                return View(model);
            }
            else
            {
                var user = await _usersData.GetUserManager(model.Email, model.Contrasenia);
                if (user != null && model.Email == user.Email && model.Contrasenia == user.Contrasenia)
                {
                    return RedirectToAction("Index", "Home");
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
                return View(model);
            }
            else
            {
                var user = await _usersData.GetUserManager(model.Email, model.Contrasenia);
                if (user == null || model.Email != user.Email || model.Contrasenia != user.Contrasenia)
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                    return View(model);
                }

                var userRol = "Usuario";
                if (user.IdRol == 1)
                {
                    userRol = "Administrador";
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nombre), // Nombre de usuario
                    new Claim(ClaimTypes.Role, userRol), // Rol del usuario
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                };
                try
                {
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                }
                catch (System.Exception)
                {

                    throw;
                }
                

                HttpContext.Session.SetString("User", user.Nombre);
                HttpContext.Session.SetInt32("UserId", user.Id);
                

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Url = "Shared/EmptyData";
                return View(await _usersData.GetAll());

            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                return View(await _usersData.GetItem(id));

            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
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
                return RedirectToAction("Error", "Home");
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
                    return View(model);
                }

                model.IdRol = 2;
                var result = _usersData.Create(model);
                return RedirectToAction(nameof(LogIn));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: UserController/Edit/5
        //[Authorize]
        [TypeFilter(typeof(RoleAuthorizationFilter), Arguments = new object[] { "Administrador" })]
        
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

                var result = _usersData.Update(model, id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
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
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
