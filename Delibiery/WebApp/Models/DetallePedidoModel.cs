using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class DetallePedidoModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public double Monto { get; set; }
        public List<ItemPedido> Articulos { get; set; }
    }
    public class ItemPedido {
        public int Renglon { get; set; }
        public string ImgUrl { get; set; }
        public string Descripcion { get; set; }
        public int cantidadPedida { get; set; }
    }
}