using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class Promocion
    {

        public int id { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public Articulo articulo { get; set; }

        // Promocion XY
        public int cantLleva { get; set; }
        public int cantPaga { get; set; }

        // Promocion Descuento
        public int descuento { get; set; }
        public int cantidadLlevar { get; set; }


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


        public PromoAlgoritmo getPromocion(string tipo)
        {
            PromoAlgoritmo algoritmo;

            switch (this.tipo.ToUpper())
            {
                case "XY":
                    algoritmo = new PromoXy(this.cantLleva, this.cantPaga, this.articulo);
                    break;

                case "DESCUENTO":
                    algoritmo = new PromoDescuento(this.descuento, this.cantidadLlevar, this.articulo);
                    break;
                
                default:
                    algoritmo = null;
                    break;
            }

            return algoritmo;

        }



    }
}
 
 