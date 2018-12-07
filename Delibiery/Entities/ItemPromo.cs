using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ItemPromo
    {
        public int Id { get; set; }
        //public PromoAlgoritmo Promo { get; set; }
        public int IdPromo { get; set; }
        public Articulo Articulo { get; set; }
        public int Cant { get; set; }
        public double Precio { get; set; }


        public ItemPromo() { }

        public ItemPromo(Promocion promo, Articulo articulo, int cant, double precio)
        {
            this.IdPromo  = promo.Id;
            this.Articulo = articulo;
            this.Cant     = cant;
            this.Precio   = precio;
        }

        /*
        public ItemPromo2(PromoAlgoritmo promo, Articulo articulo, int cant)
        {
            this.Promo = promo;
            this.Articulo = articulo;
            this.Cant = cant;
            this.Precio = Promo.promoPrecio(this.Articulo) * Cant;
        }
        */
    }
}
