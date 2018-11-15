using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PedidosController : Controller
    {
        public ActionResult Confirmar(string id)
        {

          var lista = (List<Articulo>)Session[id];
            PedidosSelecModel seleccionados = new PedidosSelecModel();
            List <PedidoModel> pedidos = new List<PedidoModel>();
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

    }

}