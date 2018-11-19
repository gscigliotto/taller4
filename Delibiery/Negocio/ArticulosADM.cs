using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Negocio
{
    public class ArticulosADM
    {
        ContextDB db;
        public ArticulosADM()
        {
            db = new ContextDB();
        }
        public ArticulosADM(ContextDB db)
        {
            this.db = db;
        }

        public List<Articulo> obtenerArticulosPortada() {
            return db.Articulos.ToList();
        }

    }
}
