using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Promocion
    {

        public Promocion() { }



        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        //public Articulo articulo { get; set; }  TODO chk si queda el art aca o lo sacamos
        public string Url { get; set; }
        // Promocion XY
        public int CantLleva { get; set; }
        public int CantPaga { get; set; }

        // Promocion Descuento
        public int Descuento { get; set; }
        public int CantidadLlevar { get; set; }


        
        public Promocion( string tipo, string descripcion,  int cantLleva, int cantPaga, int descuento, int cantidadLlevar,string url)
        {
            
            this.Tipo = tipo;
            this.Descripcion = descripcion;
            this.CantLleva = cantLleva;
            this.CantPaga = cantPaga;
            this.Descuento = descuento;
            this.CantidadLlevar = cantidadLlevar;
            this.Url = url;
        }
        






    }
}
 
 