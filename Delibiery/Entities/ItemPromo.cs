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
        public PromoAlgoritmo Promo { get; set; }
        public int Cant { get; set; }
        public double Precio { get; set; }


        public ItemPromo() { }

        public ItemPromo(PromoAlgoritmo promo, int cant, double Precio) { }
    }
}
