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
            return View(db.articulos.ToList());
        }

        // GET: Articuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.articulos.Find(id);
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
                db.articulos.Add(articulo);
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
            Articulo articulo = db.articulos.Find(id);
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

                Articulo articulo = db.articulos.Find(aux.Id);
                if (articulo == null)
                {
                    return HttpNotFound();
                }

                articulo.estilo = aux.estilo;
                articulo.marca = aux.marca;
                articulo.descripcion = aux.descripcion;
                articulo.stock = aux.stock;
                articulo.precio = aux.precio;
                                                                      
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
            Articulo articulo = db.articulos.Find(id);
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
            Articulo articulo = db.articulos.Find(id);
            db.articulos.Remove(articulo);
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


            Articulo articulo = db.articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }

            articulo.imagen = fileData;
            db.Entry(articulo).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        //return View();

    }
}
