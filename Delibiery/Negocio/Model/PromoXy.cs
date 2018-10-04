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
            this.cantLleva = cantLleva;  // Cantidad a llevar
            this.cantPaga  = cantPaga;  // Cantidad a pagar
        }


        public override double promoPrecio()
        {
            throw new NotImplementedException();

            //return cantPaga * articulo.precio;

        }

        public override int promoStock()
        {
            //throw new NotImplementedException();

            return cantLleva;

        }
    }
}