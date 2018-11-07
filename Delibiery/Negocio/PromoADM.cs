using Datos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PromoADM
    {
        ContextDB db;
        public PromoADM()
        {
            db = new ContextDB();
        }


        public PromoADM(ContextDB db)
        {
            this.db = db;
        }

        public List<Promocion> obtenerPromos()
        {
            return db.promos.ToList();
        }

        public Promocion buscarPromo(int id)
        {
            return db.promos.SingleOrDefault(p => p.id == id);
        }

        public void crearPromo(Promocion promocion)
        {
            db.promos.Add(promocion);
            db.SaveChanges();
        }
    }
}
