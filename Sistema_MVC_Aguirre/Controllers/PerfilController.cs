using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Filters;
using Sistema_MVC_Aguirre.Models;

namespace Sistema_MVC_Aguirre.Controllers
{
    public class PerfilController : Controller
    {
        private Usuario _usuario = new Usuario();
        // GET: Perfil
        public ActionResult Index()
        {
            return View(_usuario.Obtener(SessionHelper.GetUser()));
        }

        public JsonResult Actualizar(Usuario model, HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();
            ModelState.Remove("usuario_id");
            ModelState.Remove("persona_id");
            ModelState.Remove("usuario1");
            ModelState.Remove("persona_id");
            ModelState.Remove("clave");
            ModelState.Remove("nivel");
            ModelState.Remove("estado");

            if (ModelState.IsValid)
            {
                rm = model.GuardarPerfil(foto);
            }
            rm.href = Url.Content("/Default/Index");
            return Json(rm);
        }
    }
}