using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Model
{
    public class PromoDescuento : PromoAlgoritmo
    {

        public PromoDescuento(int descuento)
        {
            Descuento = descuento;
        }


        public override double promoPrecio(Articulo articulo)
        {
            return (articulo.Precio * (1 - (Descuento / 100)));

        }

        public override int promoStock()
        {
            return 1;
        }
    }
}