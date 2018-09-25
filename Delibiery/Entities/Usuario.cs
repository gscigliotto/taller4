using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public int ID { get; set; }
        public String nombre   { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int edad { get; set; }
   
        public string password { get; set; }
        public List<Rol> roles { get; set; }
        public DateTime fecha_alta { get; set; }

        
    }
}
