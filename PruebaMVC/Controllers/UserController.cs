using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC.Models.TableViewModel;
using PruebaMVC.Models;
using PruebaMVC.Models.ViewModel;

namespace PruebaMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var lst = new List<UserModel>();
            using (var db = new mvcalmarEntities()) {
                lst = (from d in db.Usuario
                       where d.estado == 1
                       select new UserModel
                       {
                           id = d.id,
                           usuario = d.usuario1,
                           edad = d.edad
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            using(var db = new mvcalmarEntities())
            {
                var user = new Usuario();
                user.estado = 1;
                user.usuario1 = model.usuario;
                user.edad = model.edad;
                user.clave = model.clave;

                db.Usuario.Add(user);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/User"));
        }
    }
}