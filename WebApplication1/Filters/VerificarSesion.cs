using MusicaLMFL.Controllers;
using MusicaLMFL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace Libreria_V6.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (TUsuario)HttpContext.Current.Session["usuario"];

            if (user == null)
            {
                if (filterContext.Controller is InicioController  == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
