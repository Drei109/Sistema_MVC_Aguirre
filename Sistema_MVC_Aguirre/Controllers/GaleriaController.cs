using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Models;
using Sistema_MVC_Aguirre.Filters;

namespace Sistema_MVC_Aguirre.Controllers
{
    [Autenticado]
    public class GaleriaController : Controller
    {
        private Galeria galeria = new Galeria();
        private Categoria categoria = new Categoria();

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
            ViewBag.Categoria2 = categoria.Listar();
            return View(
                    id == 0 ? new Galeria() : galeria.Obtener(id)
                );
        }

        [HttpPost]
        public ActionResult Guardar(Galeria galeria)
        {
            ViewBag.Categoria2 = categoria.Listar();
            
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