using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using System.Collections.Generic;
using Negocio.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaFelatio()
        {
            

            List<PedidoArt> articulosIds = cargarArticulosIds();
            List<PedidoPromoArt> promoArts = cargarPromosArts();

            PedidoADM admPedido = new PedidoADM();

            admPedido.crarPedido(articulosIds, promoArts);

        }

        private List<PedidoPromoArt> cargarPromosArts()
        {
            throw new NotImplementedException();
        }

        private List<PedidoArt> cargarArticulosIds()
        {
            throw new NotImplementedException();
        }
    }
}
