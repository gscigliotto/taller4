using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Promocion
    {

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        //public Articulo articulo { get; set; }  TODO chk si queda el art aca o lo sacamos

        // Promocion XY
        public int CantLleva { get; set; }
        public int CantPaga { get; set; }

        // Promocion Descuento
        public int Descuento { get; set; }
        public int CantidadLlevar { get; set; }


                       /*                                           W
        public Promocion(int id, string tipo, string descripcion, Articulo articulo, int cantLleva, int cantPaga, int descuento, int cantidadLlevar)
        {
            this.id = id;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.articulo = articulo;
            this.cantLleva = cantLleva;
            this.cantPaga = cantPaga;
            this.descuento = descuento;
            this.cantidadLlevar = cantidadLlevar;
        }
        */






    }
}
 
 