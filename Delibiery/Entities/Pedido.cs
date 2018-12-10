using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdSolicitante { get; set; }

        public ePedido estado { get; set; }
        public DateTime Fecha { get; set; }
        public List<ItemArticulo> Items { get; set; }
        public List<ItemPromo> Promos { get; set; }
        public double Total { get; set; }

        public enum ePedido { INCIADO=1,PROCESO=2,ENTREGADO=3,ANULADO=4}
        public Pedido(DateTime fecha, List<ItemArticulo> items, List<ItemPromo> promos, double total)
        {
            this.Fecha  = fecha;
            this.Items  = items;
            this.Promos = promos;
            this.Total  = total;
            this.estado = ePedido.INCIADO;
        }
        public Pedido()
        {
        }

    }
}
