using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{

    public class PromoModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Seleccione un tipo de promoción")]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }



        [Required(ErrorMessage = "Elija una imagen para la promo.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Solo formato de imagen aceptados.")]
        [Display(Name = "Imagen")]

        public byte[] img { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }


        [Required]
        [Display(Name = "Articulo")]
        public Articulo articulo { get; set; }

        // Promocion XY
        [Display(Name = "Cantidad que Lleva")]
        public int cantLleva { get; set; }

        [Display(Name = "Cantidad que Paga")]
        public int cantPaga { get; set; }

        // Promocion Descuento

        [Display(Name = "% de descuento")]
        public int descuento { get; set; }

        [Display(Name = "Cantidad que Lleva")]
        public int cantidadLlevar { get; set; }
    }
}