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
            var rmUsuario = new ResponseModel();
            var rmPersona = new ResponseModel();
            var persona = model.Persona;

            ModelState.Remove("usuario_id");
            ModelState.Remove("persona_id");
            ModelState.Remove("usuario1");
            ModelState.Remove("clave");
            ModelState.Remove("nivel");
            ModelState.Remove("estado");
            ModelState.Remove("Persona.persona_id");
            ModelState.Remove("Persona.dni");
            ModelState.Remove("Persona.apellido");
            ModelState.Remove("Persona.nombre");
            ModelState.Remove("Persona.estado");

            if (ModelState.IsValid)
            {
                rmUsuario = model.GuardarPerfil(foto);
                rmPersona = persona.GuardarPerfil(persona);
            }
            rmUsuario.href = Url.Content("/Default/Index");
            return Json(rmUsuario);
        }
    }
}