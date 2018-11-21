using Entities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp.Models;
using Negocio;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PromocionADM promo = new PromocionADM();
            
            ViewBag.promos=promo.obtenerPromos();
            ViewBag.articulos = new ArticulosADM().obtenerArticulosPortada();
            return View();
        }
        public ActionResult Err()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Delibiery.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ponete en contacto!.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nombre,apellido,mail,edad,usuario,password")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                List<Rol> rolesAsignados = new List<Rol>();

                UsuarioADM admUsuario = new UsuarioADM();
                rolesAsignados.Add(new Rol {rol= (int) eRoles.cliente });
                usuario.roles = rolesAsignados;
                admUsuario.registrarUsuario(usuario);
                System.Web.HttpContext.Current.Session["sessionString"] = new JavaScriptSerializer().Serialize(usuario);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Registrarte!";

            return View();
        }



        [HttpPost]
        public JsonResult RecuperarPassMail(string mail)
        {
            JsonResult rta = new JsonResult();
            UsuarioADM usuarioNeg = new UsuarioADM();
            try
            {
                usuarioNeg.recueperarPass(mail);
                rta.Data = "ok";
            }
            catch (Exception e)
            {
                rta.Data = "Err" + e.Message;

            }
            return rta;
        }
        public ActionResult Recuperar() {

            return View();
        }


        public static Dictionary<int, MenuModel> obtenerMenu() {
            //administrador = 1,operador=2, cliente = 3
            Dictionary<int, MenuModel> items = new Dictionary<int, MenuModel>();
            items.Add(1, new MenuModel { descripcion = "Mis Pedidos", roles = "1,2,3", actionName = "MisPedidos", controllerName = "Pedidos" });
            items.Add(2, new MenuModel { descripcion = "Pedidos", roles = "1,2", actionName = "Index", controllerName = "Pedidos" });
            items.Add(3, new MenuModel { descripcion = "Usuarios", roles = "1", actionName = "Index", controllerName = "Usuarios" });
            //items.Add(4, new MenuModel { descripcion = "Cambiar de estado pedido", roles = "1,2", actionName = "Cambiar", controllerName = "Pedidos" });
            items.Add(4, new MenuModel { descripcion = "Articulos", roles = "1,2,3", actionName = "Index", controllerName = "Articulos" });
            items.Add(5, new MenuModel { descripcion = "Promociones", roles = "1,2", actionName = "Index", controllerName = "Promo" });

            return items;
        }

        public static bool esPaginaSegura(string controllerName, string actionName)
        {
            bool esSegura = false;
            switch (controllerName) {

                case "Pedidos":
                    esSegura = true;
                    break;
                case "Usuarios":
                    esSegura = true;
                    break;
                case "Articulos":
                    esSegura = true;
                    if (actionName=="Details"  ) {
                        esSegura = false;
                    }
                    
                    break;
                case "Promo":
                    esSegura = true;
                    break;

            }

            return esSegura;
        }




    }

}