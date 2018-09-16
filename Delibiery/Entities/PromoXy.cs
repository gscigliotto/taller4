using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class PromoXy : PromoAlgoritmo
    {
        public int cantLleva { get; set; }
        public int cantPaga { get; set; }
        public Articulo articulo { get; set; }


        public PromoXy(int cantLleva, int cantPaga, Articulo articulo)
        {
            this.cantLleva = cantLleva;  // Cantidad a llevar
            this.cantPaga = cantPaga;  // Cantidad a pagar
            this.articulo = articulo;
        }


        public override double promoPrecio()
        {
            //throw new NotImplementedException();

            return cantPaga * articulo.precio;

        }

        public override int promoStock()
        {
            //throw new NotImplementedException();

            return cantLleva;

        }
    }
}