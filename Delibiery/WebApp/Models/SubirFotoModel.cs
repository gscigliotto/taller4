using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
namespace WebApp.Models
{
    public class SubirFotoModel:Articulo
    {
        public int id { get; set; }
        public HttpPostedFileBase file { get; set; }


    }



    
}