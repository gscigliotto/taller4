using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public abstract class PromoAlgoritmo
    {
        public virtual int Descuento { get; set; }
        //public virtual int CantidadLlevar { get; set; }

        public virtual int CantLleva { get; set; }
        public virtual int CantPaga { get; set; }


        public abstract double promoPrecio(Articulo articulo);
        public abstract int promoStock();


    }
}