using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Articulo
    {
        public int Id { get; set; }

        public string estilo { get; set; }

        public string marca { get; set; }
        
        public string descripcion { get; set; }

        public int stock { get; set; }

        public double precio { get; set; }

        public byte[] imagen { get; set; }


    }


}
