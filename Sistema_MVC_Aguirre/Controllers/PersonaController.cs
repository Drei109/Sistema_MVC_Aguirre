using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Models;

namespace Sistema_MVC_Aguirre.Controllers
{
    public class PersonaController : Controller
    {

        private Persona persona = new Persona();

        // GET: Persona
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(persona.Listar());

            }
            else
            {
                return View(persona.Buscar(criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(persona.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                    criterio == null || criterio == "" ? persona.Listar() : persona.Buscar(criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                    id == 0 ? new Persona() : persona.Obtener(id)
                );
        }

        public ActionResult Guardar(Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.Guardar();
                return Redirect("~/Persona");
            }
            else
            {
                return View("~/Views/Persona/AgregarEditar.cshtml", persona);
            }

        }

        public ActionResult Eliminar(int id)
        {
            persona.persona_id = id;
            persona.Eliminar();
            return Redirect("~/Persona");
        }
    }
}