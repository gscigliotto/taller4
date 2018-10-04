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
    class PedidoADM
    {

        ContextDB db;

        public PedidoADM(){
            db = new ContextDB();
        }
        public PedidoADM(ContextDB db){
            this.db = db;
        }


        public Pedido crarPedido(List<PedidoArt> articulosIds, List<PedidoPromoArt> promoArts) {

            PromocionADM promoADM = new PromocionADM();

            Pedido pedido = new Pedido();

            ItemArticulo item;
            ItemPromo promo;

            List<ItemArticulo> items = new List<ItemArticulo>();
            List<ItemPromo> promos = new List<ItemPromo>();


            foreach (PedidoArt pedArt in articulosIds) {

                Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == pedArt.ArtID);
                if (articulo == null)
                    throw new Exception("Error al armar el pedido - No existe el articulos");

                double precio = articulo.precio * pedArt.Cant;

                item = new ItemArticulo(articulo, pedArt.Cant, precio);

                items.Add(item);
            }


            foreach (PedidoPromoArt pedPromoArt in promoArts) {

                Promocion promocion = db.Promociones.SingleOrDefault(p => p.Id == pedPromoArt.PromoId);
                if (promocion == null)
                    throw new Exception("Error al armar el pedido - No existe la promocion");

                PromoAlgoritmo promoAlgoritmo = promoADM.getAlgoritmoFromPromo(promocion);

                

            }



            return pedido;

        }




    }
}
