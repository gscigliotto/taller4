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
            double porcent =(double) Descuento / 100;
            double coef = (1 - porcent);
            return ((articulo.Precio) * coef);

        }

        public override int promoStock()
        {
            return 1;
        }
    }
}