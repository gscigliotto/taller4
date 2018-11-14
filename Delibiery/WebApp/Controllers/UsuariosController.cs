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
using PagedList;


namespace WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        //private ContextDB db = new ContextDB();
        private int resultados=5;
        // GET: Usuarios
        public ActionResult Index(int ? page)
        {
            int pageNumber = (page ?? 1);
            return View(new UsuarioADM().obtenerUsuarios().ToPagedList(pageNumber, 3));
        }


        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = new UsuarioADM().buscarUsuario(id);
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
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Mail,Edad,usuario,Password")] Usuario usuario)
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
            int idUsuario;
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = new UsuarioADM().buscarUsuario((int)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> Roles = new List<SelectListItem>();
            List<SelectListItem> ddlitemlist = new List<SelectListItem>();
            SelectListItem RolesAdmin = new SelectListItem() { Text ="Administrador", Value = "1" };
            SelectListItem RolesOperador = new SelectListItem() { Text = "Operador", Value = "2" };
            SelectListItem RolesCliente = new SelectListItem() { Text = "Cliente", Value = "3" };
            Roles.Add(RolesAdmin);
            Roles.Add(RolesCliente);
            Roles.Add(RolesOperador);
            
            foreach (SelectListItem item in Roles) {
                int contador = 0;
                bool Encontre = false;
                while (usuario.Roles.Count>contador && !Encontre) {
                    Rol rol = usuario.Roles[contador];
                    if (item.Value == rol.rol.ToString())
                    {
                        item.Selected = true;
                        Encontre = true;

                    }

                    contador++;

                }

                ddlitemlist.Add(item);

            }


            ViewBag.ddlitemlist = ddlitemlist; //using ViewBag to bind DropDownList


            return View(usuario);
        }





        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Mail,Edad,usuario,Password")] Usuario usuario,FormCollection form)
        {
            string roles = (string)form["Roles"];
            string[] ArrayRoles= roles.Split(',');
            List<Rol> Roles = new List<Rol>();
            foreach (string id in ArrayRoles) {
                Roles.Add(new Rol { rol = int.Parse(id)});

            }
            usuario.FechaAlta = DateTime.Now;

            if (ModelState.IsValid)
            {

                new UsuarioADM().actualizarRolUsuario(usuario, Roles);
                return RedirectToAction("Index");
            }

            //DDLGetInitData() method get the DropDownList Init data
            //according to the selected value to set the default selected value.
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = new UsuarioADM().buscarUsuario(id);
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
            new UsuarioADM().borrarUsuario(id);

            return RedirectToAction("Index");
        }




        [HttpPost, ActionName("RecuperarPass")]
          
        public JsonResult RecuperarPass(int id)
        {
            JsonResult rta = new JsonResult();
            UsuarioADM usuarioNeg = new UsuarioADM();
            try
            {
                usuarioNeg.recueperarPass(id);
                rta.Data = "ok";
            }
            catch (Exception e) {
                rta.Data = "Err"+ e.Message; 

            }
            return rta;
        }







        // GET: Usuarios/Create
        public ActionResult Recuperar()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
