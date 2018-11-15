using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datos;
using Entities;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ArticulosController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Articuloes
        public ActionResult Index()
        {
            ArticuloModel a = new ArticuloModel() { articulos = db.Articulos.ToList() };
            return View(a);
        }




        // GET: Articuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: Articuloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articuloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,estilo,marca,descripcion,stock,precio")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,estilo,marca,descripcion,stock,precio")] Articulo aux)
        {
            if (ModelState.IsValid)
            {

                Articulo articulo = db.Articulos.Find(aux.Id);
                if (articulo == null)
                {
                    return HttpNotFound();
                }

                articulo.Estilo = aux.Estilo;
                articulo.Marca = aux.Marca;
                articulo.Descripcion = aux.Descripcion;
                articulo.Stock = aux.Stock;
                articulo.Precio = aux.Precio;
                                                                      
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aux);
        }

        // GET: Articuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulos.Find(id);
            db.Articulos.Remove(articulo);
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

        // GET: Articuloes/SubirFoto
        //public ActionResult SubirFoto()
        //{
        //    return View();
        //}
        public ActionResult SubirFoto(int id)
        {
            SubirFotoModel foto = new SubirFotoModel();
            foto.id = id;
            return View(foto);
        }
        [HttpPost]
        public ActionResult Subirfoto(HttpPostedFileBase file, int id)
        {
            var length = file.InputStream.Length;
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }


            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }

            articulo.Imagen = fileData;
            db.Entry(articulo).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        //return View();

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(List<Articulo> articulos)
        {
            var guid = Guid.NewGuid();
            Session[guid.ToString()] = new List<Articulo>();
            List <int> artSeleccionados = new List<int>();
            int j = 0;
            foreach (var i in articulos)
            {
                if (i.Agregado == true)
                {

                    //artSeleccionados.Add(i.Id);
                    ((List<Articulo>)Session[guid.ToString()]).Add(i);

                }
                
            }
            return RedirectToAction("Confirmar", "Pedidos", new { id = guid.ToString() });
        }


    }
}
