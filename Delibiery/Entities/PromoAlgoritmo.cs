using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public abstract class PromoAlgoritmo
    {
        public abstract double promoPrecio();
        public abstract int promoStock();
    }
}