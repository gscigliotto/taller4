using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public abstract class PromoAlgoritmo
    {
        public abstract double promoPrecio();
        public abstract int promoStock();

        public virtual int descuento { get; set; }
        public virtual int cantidadLlevar { get; set; }

        public virtual int cantLleva { get; set; }
        public virtual int cantPaga { get; set; }
    }
}