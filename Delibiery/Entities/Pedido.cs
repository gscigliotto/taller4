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
        public DateTime fecha { get; set; }
        public List<ItemArticulo> items { get; set; }
        public List<ItemPromo> promos { get; set; }
        public double total { get; set; }
    }
}
