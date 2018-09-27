using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
                List<Rol> rolesAsignados = new List<Rol>();

                UsuarioADM admUsuario = new UsuarioADM();
                rolesAsignados.Add(new Rol {rol= (int) eRoles.administrador });
                usuario.roles = rolesAsignados;
                admUsuario.registrarUsuario(usuario);
                System.Web.HttpContext.Current.Session["sessionString"] = new JavaScriptSerializer().Serialize(usuario);

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