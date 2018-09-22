using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Configuration;
using System.Data.Entity;

namespace Datos
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<Articulo> articulos { get; set; }
        //public DbSet<PromoAlgoritmo> promos { get; set; }
        public DbSet<ItemArticulo> itemsArticulos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


    }
}
