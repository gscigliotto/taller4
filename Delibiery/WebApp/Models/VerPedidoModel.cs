using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class VerPedidoModel
    {
        public Pedido pedido { get; set; }
        public Usuario usuario { get; set; }
    }
}