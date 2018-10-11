using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class PedidoArt
    {
        public int ArtID { get; set; }
        public int Cant { get; set; }


        public PedidoArt() { }

        public PedidoArt(int artID, int cant) {
            this.ArtID = artID;
            this.Cant  = cant;
        }
    }
}
