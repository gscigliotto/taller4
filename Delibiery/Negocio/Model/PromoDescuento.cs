using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Model
{
    public class PromoDescuento : PromoAlgoritmo
    {

        public PromoDescuento(int descuento, int cantidadLlevar)
        {
            this.descuento      = descuento;
            this.cantidadLlevar = cantidadLlevar;
        }


        public override double promoPrecio()
        {
            //throw new NotImplementedException();

            return (this.cantidadLlevar * this.descuento / 100);

        }

        public override int promoStock()
        {
            //throw new NotImplementedException();

            return (this.cantidadLlevar);

        }
    }
}