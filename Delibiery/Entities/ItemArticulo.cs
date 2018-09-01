using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ItemArticulo
    {
        public int Id { get; set; }
        public Articulo articulo { get; set; }
        public int cant { get; set; }
        public double precio { get; set; }
    }
}
