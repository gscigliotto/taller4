using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Promocion
    {
        private object p;
        private string v1;
        private string v2;
        private int v3;
        private int v4;
        private int v5;
        private int v6;

        public Promocion() { }

        public Promocion(object p, string v1, string v2, int v3, int v4, int v5, int v6)
        {
            this.p = p;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }

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
 
 