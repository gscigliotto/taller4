using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Datos
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<Articulo> articulos { get; set; }
        //public DbSet<PromoAlgoritmo> promos { get; set; }
        public DbSet<ItemArticulo> itemsArticulos { get; set; }
        //public DbSet<ItemPromo> itemsPromos { get; set; }

        //public DbSet<Pedido>  Pedidos { get; set; }
        
    }
}
