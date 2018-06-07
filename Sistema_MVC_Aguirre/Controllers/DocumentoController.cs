using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Models;
using Sistema_MVC_Aguirre.Filters;

namespace Sistema_MVC_Aguirre.Controllers
{
    [Autenticado]
    public class DocumentoController : Controller
    {
        private Documento documento = new Documento();
        private Categoria categoria = new Categoria();

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
            ViewBag.Categoria = categoria.Listar();
            return View(
                    id == 0 ? new Documento() : documento.Obtener(id)
                );
        }

        [HttpPost]
        public ActionResult Guardar(Documento doc, HttpPostedFileBase file, string extension)
        {
            ViewBag.Categoria = categoria.Listar();
            ModelState.Remove("nombre");
            ModelState.Remove("extension");
            ModelState.Remove("tamanio");
            ModelState.Remove("descripcion");
            ModelState.Remove("tipo");

            if (ModelState.IsValid)
            {
                doc.nombre = Path.GetFileNameWithoutExtension(file.FileName);
                doc.descripcion = file.FileName;
                doc.extension = Path.GetExtension(file.FileName);
                doc.tamanio = file.ContentLength.ToString();

                switch (doc.extension)
                {
                    case ".ppt":
                    case ".pptx":
                        doc.tipo = "Presentación";
                        break;
                    case ".doc":
                    case ".docx":
                        doc.tipo = "Documento";
                        break;
                    case ".xls":
                    case ".xlsx":
                        doc.tipo = "Cálculo";
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                        doc.tipo = "Imagen";
                        break;
                    default:
                        doc.tipo = "Otro";
                        break;
                }

                doc.Guardar(file, extension);
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