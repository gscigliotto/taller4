using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre   { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public int Edad { get; set; }
   
        public string Password { get; set; }
        public List<Rol> Roles { get; set; }
        public DateTime FechaAlta { get; set; }

    }
}
