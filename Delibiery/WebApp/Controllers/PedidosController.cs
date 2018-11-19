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
            return View(new PedidoADM().obtenerPedidos().ToPagedList(pageNumber, 3));
        }


        public ActionResult Cambiar(int id) {

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
                pedido.cant = 0;

                pedidos.Add(pedido);
            }

            seleccionados.Pedidos = pedidos;
            return View(seleccionados);
        }

        public ViewResult FinPedido(int id) {
            Pedido pedido = new PedidoADM().buscarPedido(id);
            return View(pedido);
        }

        public JsonResult ArmarPedido(PedidosSelecModel ItemsConfirmados) {
            PedidoADM pedidosManager = new PedidoADM();
            List<PedidoArt> articulos = new List<PedidoArt>();
            foreach (PedidoModel pedidoModel in ItemsConfirmados.Pedidos) {
                articulos.Add(new PedidoArt() {  ArtID=pedidoModel.idArt, Cant= pedidoModel.cant});
            }


            Pedido pedido = pedidosManager.crarPedido(articulos, null);
            pedidosManager.concretarPedido(pedido);
            
            return Json(pedido, JsonRequestBehavior.AllowGet);
        }



        public JsonResult ConfirmarPedido(Pedido pedido)
        {
            new PedidoADM().confirmarPedido(pedido);


            return Json(pedido, JsonRequestBehavior.AllowGet);
        }
    }

}