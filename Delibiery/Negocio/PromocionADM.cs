using Datos;
using Entities;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PromocionADM
    {
        ContextDB db;

        public PromocionADM()
        {
            db = new ContextDB();
        }
        public PromocionADM(ContextDB db)
        {
            this.db = db;
        }



        public PromoAlgoritmo getAlgoritmoFromPromo(Promocion promo) {

            PromoAlgoritmo algoritmo;

            switch (promo.Tipo.ToUpper())
            {
                case "XY":
                    algoritmo = new PromoXy(promo.CantLleva, promo.CantPaga);
                    break;

                case "DESCUENTO":
                    algoritmo = new PromoDescuento(promo.Descuento);
                    break;

                default:
                    algoritmo = null;
                    break;
            }

            return algoritmo;

            
        }


        public List<Promocion> obtenerPromos()
        {
            return db.Promociones.ToList();
        }

        public Promocion buscarPromo(int id)
        {
            return db.Promociones.SingleOrDefault(p => p.Id == id);
        }

        public void crearPromo(Promocion promocion)
        {
            db.Promociones.Add(promocion);
            db.SaveChanges();
        }



    }
}
