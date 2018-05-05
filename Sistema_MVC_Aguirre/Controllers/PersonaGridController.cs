﻿using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Kendo.Mvc.Extensions;
using Sistema_MVC_Aguirre.Models;
using System.Data.Entity;

namespace Sistema_MVC_Aguirre.Controllers
{
    public class PersonaService : IDisposable
    {
        private Model_Sistema db;

        public PersonaService(Model_Sistema db)
        {
            this.db = db;
        }

        public IEnumerable<Persona> Read()
        {
            return db.Persona;  
        }

        public void Create(Persona persona)
        {
            var entity = new Persona
            {
                Usuario = persona.Usuario,
                dni = persona.dni,
                apellido = persona.apellido,
                nombre = persona.nombre,
                email = persona.email,
                celular = persona.celular,
                estado = persona.estado
            };

            db.Persona.Add(entity);
            db.SaveChanges();

            persona.persona_id = entity.persona_id;
        }

        public void Update(Persona persona)
        {
            var entity = new Persona
            {
                persona_id = persona.persona_id,
                Usuario = persona.Usuario,
                dni = persona.dni,
                apellido = persona.apellido,
                nombre = persona.nombre,
                email = persona.email,
                celular = persona.celular,
                estado = persona.estado
            };

            db.Persona.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges(); 
        }

        public void Destroy(Persona persona)
        {
            var entity = new Persona
            {
                persona_id = persona.persona_id,
                Usuario = persona.Usuario,
                dni = persona.dni,
                apellido = persona.apellido,
                nombre = persona.nombre,
                email = persona.email,
                celular = persona.celular,
                estado = persona.estado
            };

            db.Persona.Attach(entity);
            db.Persona.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    public class PersonaGridController : Controller
    {
        private PersonaService personaService;

        public PersonaGridController()
        {
            personaService = new PersonaService(new Model_Sistema());
        }

        protected override void Dispose(bool disposing)
        {
            personaService.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(personaService.Read());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Persona_Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                personaService.Create(persona);

                RouteValueDictionary routeValues = this.GridRouteValues();
                return RedirectToAction("Index", routeValues);
            }

            return View("Index", personaService.Read());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Persona_Update(Persona persona)
        {
            if (ModelState.IsValid)
            {
                personaService.Update(persona);

                RouteValueDictionary routeValues = this.GridRouteValues();
                return RedirectToAction("Index", routeValues);
            }

            return View("Index", personaService.Read());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Persona_Destroy(Persona persona)
        {
            RouteValueDictionary routeValues;

            personaService.Destroy(persona);

            routeValues = this.GridRouteValues();

            return RedirectToAction("Index", routeValues);
        }
    }
}
