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

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<ItemArticulo> ItemsArticulos { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<ItemPromo> ItemsPromos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Stock> Stock { get; set; }


        //public System.Data.Entity.DbSet<Entities.Pedido> Pedidoes { get; set; }
    }
}
