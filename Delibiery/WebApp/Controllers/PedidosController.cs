using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp.Models;
using PagedList;
using Negocio.Model;

namespace WebApp.Controllers
{
    public class PedidosController : Controller
    {

        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            return View(new PedidoADM().obtenerPedidos().ToPagedList(pageNumber, 10));
        }


        public ActionResult MisPedidos(int? page)
        {
            int pageNumber = (page ?? 1);
            Entities.Usuario u = (Entities.Usuario)System.Web.HttpContext.Current.Session["usuario"];
            return View(new PedidoADM().obtenerPedidosUsuario(u.Id).ToPagedList(pageNumber, 10));
        }


        public ActionResult Cambiar(int id)
        {

            return View(new Pedido() { });
        }
        public ActionResult Confirmar(string id)
        {

            var lista = (List<Articulo>)Session[id];
            PedidosSelecModel seleccionados = new PedidosSelecModel();
            List<PedidoModel> pedidos = new List<PedidoModel>();
            foreach (var articulo in lista)
            {
                PedidoModel pedido = new PedidoModel();
                pedido.idArt = articulo.Id;
                pedido.estilo = articulo.Estilo;
                pedido.Marca = articulo.Marca;
                pedido.Descripcion = articulo.Descripcion;
                pedido.cant = 0;
                pedido.Precio = articulo.Precio;
                pedidos.Add(pedido);
            }

            seleccionados.Pedidos = pedidos;
            seleccionados.promos = new List<SelectListItem>();
            List<Promocion> promos = new PromocionADM().obtenerPromos();
            promos.ForEach(a =>
            {
                seleccionados.promos.Add(new SelectListItem() { Text = a.Descripcion, Value = Convert.ToString(a.Id) });
            });
            return View(seleccionados);
        }

        public ViewResult FinPedido(int id)
        {
            Pedido pedido = new PedidoADM().buscarPedido(id);
            return View(pedido);
        }

        public ViewResult View(int id)
        {
            VerPedidoModel pedidoModel = new VerPedidoModel();
            pedidoModel.pedido = new PedidoADM().buscarPedido(id);

            pedidoModel.usuario = new UsuarioADM().buscarUsuario(pedidoModel.pedido.IdSolicitante);


            return View(pedidoModel);
        }

        public JsonResult ArmarPedido(PedidosSelecModel ItemsConfirmados, FormCollection formvalues)
        {
            PedidoADM pedidosManager = new PedidoADM();
            Pedido pedido = null;
            List<PedidoArt> articulos = new List<PedidoArt>();
            ValueProviderResult promoid = formvalues.GetValue("promos");

            if (promoid.AttemptedValue == "")
            {


                foreach (PedidoModel pedidoModel in ItemsConfirmados.Pedidos)
                {
                    articulos.Add(new PedidoArt() { ArtID = pedidoModel.idArt, Cant = pedidoModel.cant });
                }



                pedido = pedidosManager.crarPedido(articulos, null);

            }
            else
            {
                Promocion promo = new PromocionADM().buscarPromo(Convert.ToInt32(promoid.AttemptedValue));
                PedidoModel mejorArt = new PedidoModel();
                PedidoPromoArt promos = new PedidoPromoArt();
                double major = 0;
                double calculo = 0;
                if (promo.Tipo == "DESCUENTO")
                {
                    foreach (PedidoModel pedidoModel in ItemsConfirmados.Pedidos)
                    {
                        calculo = (pedidoModel.Precio * pedidoModel.cant) - ((pedidoModel.Precio * pedidoModel.cant) * (promo.Descuento / 100));
                        if (major < calculo)
                        {
                            if (major != 0) {
                                articulos.Add(new PedidoArt() {  ArtID=mejorArt.idArt, Cant= mejorArt.cant});
                            }
                            major = calculo;
                            mejorArt = pedidoModel;
                        }
                        else
                        {
                            articulos.Add(new PedidoArt() { ArtID = pedidoModel.idArt, Cant = pedidoModel.cant });

                        }


                    }
                    List<PedidoPromoArt> promosP = new List<PedidoPromoArt>();
                    promos.ArtId = mejorArt.idArt;
                    promos.Cant = mejorArt.cant;
                    promos.PromoId = promo.Id;
                    promosP.Add(promos);
                    pedido = pedidosManager.crarPedido(articulos, promosP);

                }


            }



            Entities.Usuario u = (Entities.Usuario)System.Web.HttpContext.Current.Session["usuario"];
            pedido.IdSolicitante = u.Id;



            //pedidosManager.concretarPedido(pedido);

            return Json(pedido, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CambiarEstadoDespachado(int id)
        {
            bool cambio = true;
            PedidoADM pedidoMnger = new PedidoADM();
            pedidoMnger.DespacharPedido(id);


            return Json(cambio, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CambiarEstadoAnulado(int id)
        {
            bool cambio = true;
            PedidoADM pedidoMnger = new PedidoADM();
            pedidoMnger.AnularPedido(id);


            return Json(cambio, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CambiarEstadoProceso(int id)
        {
            bool cambio = true;
            PedidoADM pedidoMnger = new PedidoADM();
            pedidoMnger.ProcesarPedido(id);


            return Json(cambio, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ConfirmarPedido(Pedido pedido)
        {
            new PedidoADM().confirmarPedido(pedido);
            return Json(pedido, JsonRequestBehavior.AllowGet);
        }
    }

}