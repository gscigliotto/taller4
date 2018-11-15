using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MenuModel
    {
        public string descripcion { get; set; }

        public string actionName { get; set; }
        public string controllerName { get; set; }
        public string roles { get; set; }
    }
}