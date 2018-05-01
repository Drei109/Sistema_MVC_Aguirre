using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Models;


namespace Sistema_MVC_Aguirre.Controllers
{
    public class GaleriaController : Controller
    {
        private Galeria galeria = new Galeria();

        // GET: Galeria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(galeria.Listar());

            }
            else
            {
                return View(galeria.Buscar(criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(galeria.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                    criterio == null || criterio == "" ? galeria.Listar() : galeria.Buscar(criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                    id == 0 ? new Galeria() : galeria.Obtener(id)
                );
        }

        public ActionResult Guardar(Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                galeria.Guardar();
                return Redirect("~/Galeria");
            }
            else
            {
                return View("~/Views/Galeria/AgregarEditar.cshtml", galeria);
            }

        }

        public ActionResult Eliminar(int id)
        {
            galeria.galeria_id = id;
            galeria.Eliminar();
            return Redirect("~/Galeria");
        }
    }
}