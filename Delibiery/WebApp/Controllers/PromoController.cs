using AutoMapper;
using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using PagedList;
namespace WebApp.Controllers
{
    public class PromoController : Controller
    {
        private int paginaLargo=10;
        // GET: Promo
        public ActionResult Index()
        {
            PromocionADM promos = new PromocionADM();
            List<Promocion> promociones = promos.obtenerPromos();
            List<PromoModel> listPromo = new List<PromoModel>();
            foreach (Promocion prom in promociones) {
                PromoModel promoModel = new PromoModel();
                promoModel.id = prom.Id;
                // promoModel.articulo = prom.Articulo;    //TODO chk if it stays
                promoModel.cantidadLlevar = prom.CantidadLlevar;
                promoModel.cantLleva = prom.CantLleva;
                promoModel.cantPaga = prom.CantPaga;
                promoModel.descuento = prom.Descuento;
                promoModel.descripcion = prom.Descripcion;
                promoModel.tipo = prom.Tipo;
                listPromo.Add(promoModel);

            }
            //var ret = Mapper.Map<IList< Promocion  >,IList<PromoModel>>( promos.obtenerPromos());
            return View(listPromo.ToPagedList(1,paginaLargo));
        }

        // GET: Promo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Promo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Promocion promo = new Promocion();
            try
            {
                Promocion promocion = new Promocion(null, collection["tipo"], collection["descripcion"], Convert.ToInt32(collection["cantLleva"]), Convert.ToInt32(collection["cantPaga"]), Convert.ToInt32(collection["descuento"]), Convert.ToInt32(collection["cantidadLlevar"]));
                PromocionADM promoAdm = new PromocionADM();
                promoAdm.crearPromo(promocion);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Promo/Edit/5
        public ActionResult Edit(int id)
        {
            PromocionADM promoMng = new PromocionADM();
            
            return View(promoMng.buscarPromo(id));
        }

        // POST: Promo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Promo/Delete/5
        public ActionResult Delete(int id)
        {

            PromocionADM promoMng = new PromocionADM();

            return View(promoMng.buscarPromo(id));
            
        }

        // POST: Promo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
