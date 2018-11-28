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
            return View("Index", new PedidoADM().obtenerPedidosUsuario(u.Id).ToPagedList(pageNumber, 10));
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

            Entities.Usuario u = (Entities.Usuario)System.Web.HttpContext.Current.Session["usuario"];
            pedido.IdSolicitante = u.Id;
            
            
            
            pedidosManager.concretarPedido(pedido);
            
            return Json(pedido, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CambiarEstadoDespachado(int id)
        {
            bool cambio = true;
            PedidoADM pedidoMnger = new PedidoADM();
            pedidoMnger.DespacharPedido(id);


            return Json(cambio, JsonRequestBehavior.AllowGet);
        }

        public ViewResult VerDetallePedido(int id)
        {
           
            PedidoADM pedidoMnger = new PedidoADM();
            Pedido pedido = pedidoMnger.buscarPedido(id);
            DetallePedidoModel detallePedido = new DetallePedidoModel();

            detallePedido.Estado = pedido.estado.ToString();
            detallePedido.FechaPedido = pedido.Fecha;
            detallePedido.Id = pedido.Id;
            detallePedido.Monto = pedido.Total;
            detallePedido.Usuario = "cambiar";
            detallePedido.Articulos = new List<ItemPedido>();
            foreach (ItemArticulo art in pedido.Items) {

                detallePedido.Articulos.Add(new ItemPedido() { cantidadPedida = art.Cant });
            }

            return View(items);
        }


        public JsonResult ConfirmarPedido(Pedido pedido)
        {
            new PedidoADM().confirmarPedido(pedido);


            return Json(pedido, JsonRequestBehavior.AllowGet);
        }
    }

}