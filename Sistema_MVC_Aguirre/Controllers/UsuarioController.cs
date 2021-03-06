﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Aguirre.Models;
using Sistema_MVC_Aguirre.Filters;

namespace Sistema_MVC_Aguirre.Controllers
{
    [Autenticado]
    public class UsuarioController : Controller
    {

        private Usuario usuario = new Usuario();
        private Persona persona = new Persona();

        // GET: Usuario        
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(usuario.Listar());

            }
            else
            {
                return View(usuario.Buscar(criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(usuario.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(
                    criterio == null || criterio == "" ? usuario.Listar() : usuario.Buscar(criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Persona = persona.Listar();
            return View(
                
                    id == 0 ? new Usuario() : usuario.Obtener(id)
                );
        }

        public ActionResult Guardar(Usuario usuario)
        {
            ViewBag.Persona = persona.Listar();
            if (ModelState.IsValid)
            {
                usuario.Guardar();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml", usuario);
            }

        }

        public ActionResult Eliminar(int id)
        {
            usuario.usuario_id = id;
            usuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}