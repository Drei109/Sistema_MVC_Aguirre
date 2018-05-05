﻿using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Kendo.Mvc.Extensions;
using Sistema_MVC_Aguirre.Models;

namespace Sistema_MVC_Aguirre.Controllers
{
    public class DocumentoService : IDisposable
    {
        private Model_Sistema db;

        public DocumentoService(Model_Sistema db)
        {
            this.db = db;
        }

        public IEnumerable<Documento> Read()
        {
            return db.Documento;  
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    public class DocumentoGridController : Controller
    {
        private DocumentoService documentoService;

        public DocumentoGridController()
        {
            documentoService = new DocumentoService(new Model_Sistema());
        }

        protected override void Dispose(bool disposing)
        {
            documentoService.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(documentoService.Read());
        }
    }
}
