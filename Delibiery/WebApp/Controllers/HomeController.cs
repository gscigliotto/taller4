using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Delibiery.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ponete en contacto!.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nombre,apellido,mail,edad,usuario,password")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                /*
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                */
                UsuarioADM admUsuario = new UsuarioADM();
            
                admUsuario.registrarUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Registrarte!";

            return View();
        }
    }

}