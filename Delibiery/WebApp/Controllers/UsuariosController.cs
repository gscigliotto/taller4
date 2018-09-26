using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datos;
using Entities;
using WebApp.Models;
using Negocio;

namespace WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nombre,apellido,mail,edad,usuario,password")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {

                UsuarioADM admUsuario = new UsuarioADM();
                admUsuario.registrarUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> ddlitemlist = new List<SelectListItem>();
            ddlitemlist.Add(new SelectListItem() { Text = "Administrador", Value = "1" });
            ddlitemlist.Add(new SelectListItem() { Text = "Cliente", Value = "2" });
            ddlitemlist.Add(new SelectListItem() { Text = "Operador", Value = "3" });


            ViewBag.ddlitemlist = ddlitemlist; //using ViewBag to bind DropDownList


            return View(usuario);
        }





        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nombre,apellido,mail,edad,usuario,password")] Usuario usuario,FormCollection form)
        {
            string roles = (string)form["Roles"];
            string[] ArrayRoles= roles.Split(',');
            List<Rol> Roles = new List<Rol>();
            foreach (string id in ArrayRoles) {
                Roles.Add(new Rol { rol = int.Parse(id)});

            }
            usuario.fecha_alta = DateTime.Now;

            if (ModelState.IsValid)
            {

                var result = db.Usuarios.SingleOrDefault(b => b.ID == usuario.ID);
                result.roles = Roles;
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            //DDLGetInitData() method get the DropDownList Init data
            //according to the selected value to set the default selected value.
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
