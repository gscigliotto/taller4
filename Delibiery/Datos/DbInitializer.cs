using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ContextDB>//  DropCreateDatabaseAlways<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {


            var roles = new List<Rol> {
                new Rol {  rol= (int) eRoles.administrador}
            };
            var usuarios = new List<Usuario>
            {
                new Usuario { Apellido = "Admin", Edad=18, FechaAlta=DateTime.Now, Mail="admin@admin.com",Nombre="Admin" ,Password="E10ADC3949BA59ABBE56E057F20F883E", Roles=roles}
            };

            usuarios.ForEach(u => context.Usuarios.Add(u));


            var articulos = new List<Articulo>
            {
                new Articulo { Estilo="IPA", Descripcion="Cerveza IPA Marca Peñon", Marca = "Peñon", Precio=10, Stock=100, costo=1  }
            };

            articulos.ForEach(a=>  context.Articulos.Add(a) );

            var stock = new List<Stock> {
                new Stock {  IdArt=1, Cantidad=100, Costo=1, Fecha= DateTime.Now, IdPedido=0  }
            };
            stock.ForEach(s=> context.Stock.Add(s));
            /*
            var promos = new List<Promocion>
            {
                new Promocion (0, "1","Descripcion de articulo",new Articulo { Id=1 },3,2 , 0,0 )
            };
            */



            context.SaveChanges();
        }
    }

}
