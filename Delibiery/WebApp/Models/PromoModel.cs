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


        public string url;
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
        [Range(1, 1000, ErrorMessage = "La cantidad tiene que ser mayor a 0")]
        public int cantLleva { get; set; }

        [Display(Name = "Cantidad que Paga")]
        [Range(1, 1000, ErrorMessage = "La cantidad tiene que ser mayor a 0")]
        public int cantPaga { get; set; }

        // Promocion Descuento

        [Display(Name = "% de descuento")]
        [Range(1, 1000, ErrorMessage = "El %  tiene que ser mayor a 0")]
        public int descuento { get; set; }

        [Display(Name = "Cantidad que Lleva")]
        [Range(1, 1000, ErrorMessage = "La cantidad tiene que ser mayor a 0")]
        public int cantidadLlevar { get; set; }
    }
}