using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Model
{
    public class PromoXy : PromoAlgoritmo
    {

        public PromoXy(int cantLleva, int cantPaga)
        {
            CantLleva = cantLleva;  // Cantidad a llevar
            CantPaga  = cantPaga;  // Cantidad a pagar
        }


        public override double promoPrecio(Articulo articulo)
        {
            return (CantPaga * articulo.Precio);
        }

        public override int promoStock()
        {
            return CantLleva;
        }
    }
}