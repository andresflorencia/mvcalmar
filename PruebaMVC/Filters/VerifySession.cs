using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC.Controllers;
using PruebaMVC.Models;

namespace PruebaMVC.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (Usuario)HttpContext.Current.Session["User"];
            if(oUser == null)
            {
                if (!(filterContext.Controller is LoginController)) {
                    filterContext.HttpContext.Response.Redirect("~/Login");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}