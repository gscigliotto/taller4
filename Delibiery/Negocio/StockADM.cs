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
    public class StockADM
    {

        ContextDB db;

        public StockADM(){
            db = new ContextDB();
        }
        public StockADM(ContextDB db){
            this.db = db;
        }


        public List<Stock> listarStock() {
            var list = from stock in db.Stock
                       orderby stock.Fecha ascending
                       select stock;

            List<Stock> resultList = list.ToList();

            return resultList;
        }

        public List<Stock> listarStockPorArticulo(int idArt)
        {
            var list = from stock in db.Stock
                       where stock.IdArt == idArt
                       orderby stock.Fecha ascending
                       select stock;

            List<Stock> resultList = list.ToList();

            return resultList;
        }

        public void cargarStock(int idArt, Int32 idPedido, Double costo, Int32 cantidad) {
            Stock stock = new Stock(idArt, idPedido, costo, cantidad, DateTime.Now);
            db.Stock.Add(stock);
            db.SaveChanges();
        }

    }
}
