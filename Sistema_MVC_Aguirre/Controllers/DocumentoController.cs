using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Models;

namespace Sistema_MVC_Aguirre.Controllers
{
    public class DocumentoController : Controller
    {
        private Documento documento = new Documento();

        // GET: Documento
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(documento.Listar());

            }
            else
            {
                return View(documento.Buscar(criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(documento.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                    criterio == null || criterio == "" ? documento.Listar() : documento.Buscar(criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                    id == 0 ? new Documento() : documento.Obtener(id)
                );
        }

        public ActionResult Guardar(Documento documento)
        {
            if (ModelState.IsValid)
            {
                documento.Guardar();
                return Redirect("~/Documento");
            }
            else
            {
                return View("~/Views/Documento/AgregarEditar.cshtml", documento);
            }

        }

        public ActionResult Eliminar(int id)
        {
            documento.documento_id = id;
            documento.Eliminar();
            return Redirect("~/Documento");
        }
    }
}