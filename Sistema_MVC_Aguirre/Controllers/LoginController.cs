using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Models;
using Sistema_MVC_Aguirre.Filters;

namespace Sistema_MVC_Aguirre.Controllers
{
    [NoLogin]
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();

        // GET: Login        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string usuario, string password)
        {
            var rm = this.usuario.ValidarLogin(usuario, password);
            if (rm.response)
            {
                rm.href = Url.Content("/Categoria");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}