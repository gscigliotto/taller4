using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class PromoDescuento : PromoAlgoritmo
    {
        public int descuento { get; set; }
        public int cantidadLlevar { get; set; }
        public Articulo articulo { get; set; }


        public PromoDescuento(int descuento, int cantidadLlevar, Articulo articulo)
        {
            this.descuento = descuento;
            this.cantidadLlevar = cantidadLlevar;
            this.articulo       = articulo; 
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