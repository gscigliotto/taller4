using Datos;
using Entities;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        public List<Pedido> obtenerPedidos() {
            return db.Pedidos.ToList();
        }


        public List<Pedido> obtenerPedidosUsuario(int idusuario) {
            return db.Pedidos.Where(p=>p.IdSolicitante==idusuario).ToList();
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
                    throw new Exception("Error al armar el pedido - No existe el articulo "+ articulo.Descripcion);

                if (articulo.Stock < pedArt.Cant)
                    throw new Exception("Error al armar el pedido - No hay stock suficiente para el articulo cod: " + articulo.Id);

                double precio = articulo.Precio * pedArt.Cant;

                item = new ItemArticulo(articulo, pedArt.Cant, precio);

                items.Add(item);
            }

            if (promoArts != null)
            {
                foreach (PedidoPromoArt pedPromoArt in promoArts)
                {

                    Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == pedPromoArt.ArtId);
                    if (articulo == null)
                        throw new Exception("Error al armar el pedido - No existe el articulo");

                    Promocion promocion = db.Promociones.SingleOrDefault(p => p.Id == pedPromoArt.PromoId);
                    if (promocion == null)
                        throw new Exception("Error al armar el pedido - No existe la promocion");

                    PromoAlgoritmo promoAlgoritmo = promoADM.getAlgoritmoFromPromo(promocion);

                    if (articulo.Stock < (promoAlgoritmo.promoStock() * pedPromoArt.Cant))
                        throw new Exception("Error al armar el pedido - No hay stock suficiente para la promocion cod: " + promocion.Id + " con el articulo cod: " + articulo.Id);

                    //promo = new ItemPromo(promoAlgoritmo, articulo, pedPromoArt.Cant);
                    promo = new ItemPromo(promocion, articulo, pedPromoArt.Cant, promoAlgoritmo.promoPrecio(articulo));

                    promos.Add(promo);
                }
            }

            total = calcularTotalPedido(items, promos);

            pedido = new Pedido(DateTime.Now, items, promos, total);        //TODO agregar el cliente

            return pedido;

        }

        public void DespacharPedido(int id)
        {
            Pedido pedido = db.Pedidos.FirstOrDefault(p => p.Id == id);
            pedido.estado = Pedido.ePedido.ENTREGADO;
            db.SaveChanges();
        }
        public void AnularPedido(int id)
        {
            //aca sube el estock
            cancelarPedido(id);
            Pedido pedido = db.Pedidos.FirstOrDefault(p => p.Id == id);
            pedido.estado = Pedido.ePedido.ANULADO;
            db.SaveChanges();
        }

        public void ProcesarPedido(int id)
        {
            Pedido pedido = db.Pedidos.FirstOrDefault(p => p.Id == id);
            pedido.estado = Pedido.ePedido.PROCESO;
            db.SaveChanges();
        }

        public Pedido buscarPedido(int id)
        {
            return  db.Pedidos.Include("Items.Articulo").SingleOrDefault(p => p.Id == id);
        }

        public void confirmarPedido(Pedido pedido)
        {
            pedido.Fecha = DateTime.Now;

            foreach(ItemArticulo itemArt in pedido.Items) {
                db.Entry<Articulo>(itemArt.Articulo).State = EntityState.Unchanged;

            }
            concretarPedido(pedido);
            //pedidoRepo.estado = Pedido.ePedido.PROCESO;
            db.SaveChanges();

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

            StockADM stockADM = new StockADM(db);
            PromocionADM promoADM = new PromocionADM(db);
            db.Pedidos.Add(pedido);
            db.SaveChanges();
            foreach (ItemArticulo item in pedido.Items)
            {
                //Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == item.Articulo.Id);
                //articulo.Stock -= item.Cant;
                stockADM.cargarStock(item.Articulo.Id, pedido.Id, 0, (item.Cant * (-1)));
            }
            if (pedido.Promos != null)
            {
                foreach (ItemPromo itemPromo in pedido.Promos)
                {
                    Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == itemPromo.Articulo.Id);
                    //articulo.Stock -= itemPromo.Promo.promoStock() * itemPromo.Cant;
                    Promocion promo = db.Promociones.SingleOrDefault(p => p.Id == itemPromo.IdPromo);
                    PromoAlgoritmo promoAlgoritmo = promoADM.getAlgoritmoFromPromo(promo);
                    stockADM.cargarStock(itemPromo.Articulo.Id, pedido.Id, 0, (promoAlgoritmo.promoStock() * itemPromo.Cant * (-1)));
                }
            }

          
           
            db.SaveChanges();

        }



        public void cancelarPedido(int idPedido) {


            StockADM stockADM = new StockADM(db);

            /*
            Pedido pedido = db.Pedidos.Include("Items.Articulo").SingleOrDefault(p => p.Id == idPedido);

            pedido.Items.ForEach(item => {

                Articulo artAct=db.Articulos.SingleOrDefault(art => art.Id == item.Articulo.Id);
                artAct.Stock = artAct.Stock + item.Cant;
            });
            foreach (ItemArticulo articulo in pedido.Items) {

            }
            */

            var list = from stock in db.Stock
                       where (stock.IdPedido == idPedido)
                       select stock;

            List<Stock> stockList = list.ToList();

            foreach (Stock stock in stockList) {
                stockADM.cargarStock(stock.IdArt, stock.IdPedido, 0, (stock.Cantidad * (-1)));
            }

            db.SaveChanges();
        }



    }
}
