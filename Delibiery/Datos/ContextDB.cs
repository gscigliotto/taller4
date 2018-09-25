using Entities;
using System.Data.Entity;

namespace Datos
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("BirrasDB")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<Articulo> articulos { get; set; }
        //public DbSet<PromoAlgoritmo> promos { get; set; }
        public DbSet<ItemArticulo> itemsArticulos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<ItemPromo> itemsPromos { get; set; }

        //public DbSet<Pedido>  Pedidos { get; set; }
        public DbSet<Rol> rol { get; set; }
    }
}
