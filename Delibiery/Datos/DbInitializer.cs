using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {

            var usuarios = new List<Usuario>
            {
                new Usuario { apellido = "Admin", edad=18, fecha_alta=DateTime.Now, mail="gscigliotto@gmail.com",nombre="Admin" ,password="E10ADC3949BA59ABBE56E057F20F883E"}
            };

            usuarios.ForEach(u => context.Usuarios.Add(u));

            context.SaveChanges();
        }
    }

}
