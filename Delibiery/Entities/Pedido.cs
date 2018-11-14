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
        public DateTime Fecha { get; set; }
        public List<ItemArticulo> Items { get; set; }
        public List<ItemPromo> Promos { get; set; }
        public double Total { get; set; }
        public Usuario Cliente { get; set; }


        public Pedido(DateTime fecha, List<ItemArticulo> items, List<ItemPromo> promos, double total)       //TODO agregar el cliente gato
        {
            this.Fecha  = fecha;
            this.Items  = items;
            this.Promos = promos;
            this.Total  = total;
            //this.Cliente = cliente;         //TODO sacar el comentaro
        }

    }
}
