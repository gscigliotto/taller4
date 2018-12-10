using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class PedidosSelecModel
    {
        public List<PedidoModel> Pedidos { get; set; }

        public string promosel { get; set; }
        public List<SelectListItem> promos { get; set; }
    }
}