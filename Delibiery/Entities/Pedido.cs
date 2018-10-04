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


        public Pedido() {
            this.Fecha = DateTime.Now;
        }

    }
}
