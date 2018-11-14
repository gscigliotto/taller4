using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ItemArticulo
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int Cant { get; set; }
        public double Precio { get; set; }


        public ItemArticulo() {
        }

        public ItemArticulo(Articulo articulo, int cant, double precio) {
            this.Articulo = articulo;
            this.Cant     = cant;
            this.Precio   = precio;
        }
   
        public ItemArticulo(int id, Articulo articulo, int cant, double precio)
        {
            this.Id       = id;
            this.Articulo = articulo;
            this.Cant     = cant;
            this.Precio   = precio;
        }
    }
}
