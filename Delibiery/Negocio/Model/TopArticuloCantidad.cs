using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    class TopArticuloCantidad
    {
        public Articulo Articulo { get; set; }
        public int CantidadVendida { get; set; }


        public TopArticuloCantidad() { }

        public TopArticuloCantidad(Articulo art, int cant)
        {
            this.Articulo = art;
            this.CantidadVendida = cant;
        }
    }
}
