using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Stock
    {
        public Int32 Id { get; set; }
        public int IdArt { get; set; }
        public Int32 IdPedido { get; set; }
        public Double Costo { get; set; }
        public Int32 Cantidad { get; set; }
        public DateTime Fecha { get; set; }


        public Stock() { }

        public Stock(int idArt, Int32 idPedido, Double costo, Int32 cantidad, DateTime fecha)
        {
            this.IdArt = idArt;
            this.IdPedido = idPedido;
            this.Costo = costo;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }

        public Stock(Int32 id, int idArt, Int32 idPedido, Double costo, Int32 cantidad, DateTime fecha) {
            this.Id = id;
            this.IdArt = idArt;
            this.IdPedido = idPedido;
            this.Costo = costo;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }
    }
}
