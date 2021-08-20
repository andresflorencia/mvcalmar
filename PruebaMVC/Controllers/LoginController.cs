using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC.Models;

namespace PruebaMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string usuario, string clave) {
            try
            {
                using(var db = new mvcalmarEntities())
                {
                    var oUser = from d in db.Usuario 
                                where d.usuario1 == usuario && d.clave == clave && d.estado == 1 
                                select d;
                    if (oUser.Count() > 0)
                    {
                        Session["User"] = oUser.First();
                        return Content("1");
                    }
                    else
                        return Content("Usuario o contraseña incorrecta.");

                }
            }
            catch (Exception e) {
                return Content("Error:" +  e.Message);
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null; 
            return Index();
        }
    }
}