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
    public class PedidoADM
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

            Pedido pedido;

            double total = 0;

            ItemArticulo item;
            ItemPromo promo;

            List<ItemArticulo> items = new List<ItemArticulo>();
            List<ItemPromo> promos = new List<ItemPromo>();


            foreach (PedidoArt pedArt in articulosIds) {

                Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == pedArt.ArtID);
                if (articulo == null)
                    throw new Exception("Error al armar el pedido - No existe el articulos");

                if (articulo.Stock < pedArt.Cant)
                    throw new Exception("Error al armar el pedido - No hay stock suficiente para el articulo cod: " + articulo.Id);

                double precio = articulo.Precio * pedArt.Cant;

                item = new ItemArticulo(articulo, pedArt.Cant, precio);

                items.Add(item);
            }


            foreach (PedidoPromoArt pedPromoArt in promoArts) {

                Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == pedPromoArt.ArtId);
                if (articulo == null)
                    throw new Exception("Error al armar el pedido - No existe el articulo");

                Promocion promocion = db.Promociones.SingleOrDefault(p => p.Id == pedPromoArt.PromoId);
                if (promocion == null)
                    throw new Exception("Error al armar el pedido - No existe la promocion");

                PromoAlgoritmo promoAlgoritmo = promoADM.getAlgoritmoFromPromo(promocion);

                if (articulo.Stock < (promoAlgoritmo.promoStock() * pedPromoArt.Cant))
                    throw new Exception("Error al armar el pedido - No hay stock suficiente para la promocion cod: " + promocion.Id + " con el articulo cod: " + articulo.Id);

                promo = new ItemPromo(promoAlgoritmo, articulo, pedPromoArt.Cant);

                promos.Add(promo);
            }


            total = calcularTotalPedido(items, promos);

            pedido = new Pedido(DateTime.Now, items, promos, total);

            return pedido;

        }

        private double calcularTotalPedido(List<ItemArticulo> items, List<ItemPromo> promos)
        {
            double total = 0;

            foreach (ItemArticulo item in items)
            {
                total += item.Precio;
            }

            foreach (ItemPromo promo in promos)
            {
                total += promo.Precio;
            }

            return total;
        }



        public void concretarPedido(Pedido pedido)
        {

            foreach (ItemArticulo item in pedido.Items)
            {
                Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == item.Articulo.Id);
                articulo.Stock -= item.Cant;
                db.SaveChanges();
            }

            foreach (ItemPromo itemPromo in pedido.Promos)
            {
                Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == itemPromo.Articulo.Id);
                //articulo.Stock -= itemPromo.Promo.promoStock() * itemPromo.Cant;
                db.SaveChanges();
            }



        }

    }
}
