using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace WebApp.Models
{
    public class ArticuloModel
    {
        public List<Articulo> articulos { get; set; }
        public PagedList.IPagedList <Articulo> articulosPaginado { get; set; }
    }
}