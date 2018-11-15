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

        public string Estilo  { get; set; }

        public string Marca { get; set; }
        
        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public double Precio { get; set; }

        public byte[] Imagen { get; set; }
        public Boolean Agregado { get; set; }


    }


}
