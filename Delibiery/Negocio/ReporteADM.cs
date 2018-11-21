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
    class ReporteADM
    {
        ContextDB db;


        public ReporteADM()
        {
            db = new ContextDB();
        }
        public ReporteADM(ContextDB db)
        {
            this.db = db;
        }



        public List<Pedido> listarPedidos(int idCliente)
        {

            var list = from pedido in db.Pedidos
                       where pedido.IdSolicitante == idCliente
                       select pedido;

            List<Pedido> resultList = list.ToList();

            return resultList;
        }



        public List<Pedido> listarPedidos()
        {
            var list = from pedido in db.Pedidos
                       select pedido;

            List<Pedido> resultList = list.ToList();

            return resultList;
        }


        public List<TopArticuloCantidad> listarTopArticulos(DateTime fecDesde, DateTime fecHasta)
        {
            Dictionary<int, int> articuloCantidad = new Dictionary<int, int>();
            List<TopArticuloCantidad> articuloList = new List<TopArticuloCantidad>();

            var list = from pedido in db.Pedidos
                       where (pedido.Fecha >= fecDesde && pedido.Fecha <= fecHasta)
                       select pedido;
                     
            List<Pedido> pedidoList = list.ToList();

            foreach (Pedido pedido in pedidoList)
            {
                foreach (ItemArticulo itemArticulo in pedido.Items)
                {
                    articuloCantidad = agregarCantidad(articuloCantidad, itemArticulo.Id, itemArticulo.Cant);
                }

                foreach (ItemPromo itemPromo in pedido.Promos)
                {
                    articuloCantidad = agregarCantidad(articuloCantidad, itemPromo.Articulo.Id, itemPromo.Cant);
                }
            }

            articuloList = ordernarListaDeArticulosDesdeUnDicctionario(articuloCantidad);

            return articuloList;
        }



        private List<TopArticuloCantidad> ordernarListaDeArticulosDesdeUnDicctionario(Dictionary<int, int> articuloCantidad)
        {
            TopArticuloCantidad artCant;
            List<TopArticuloCantidad> artList = new List<TopArticuloCantidad>();
            articuloCantidad.OrderByDescending(i => i.Value);

            foreach (KeyValuePair<int, int> entry in articuloCantidad)
            {
                Articulo articulo = db.Articulos.SingleOrDefault(a => a.Id == entry.Key);

                artCant = new TopArticuloCantidad(articulo, entry.Value);

                artList.Add(artCant);
            }

            return artList;
        }



        private Dictionary<int, int> agregarCantidad(Dictionary<int, int> dic, int idArt, int cant)
        {
            int value = 0;

            if (!dic.TryGetValue(idArt, out value))     /* key doesn't exist */
            {
                dic[idArt] = cant;
            }
            else   /* key exists */
            {
                value += cant;
                dic[idArt] = value;
            }

            return dic;
        }


        
    }
}
