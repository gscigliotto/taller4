
using Datos;
using Entities;
using System;

using System.Linq;


namespace Negocio
{
    public class UsuarioADM
    {
        ContextDB db;
        public UsuarioADM() {
           db = new ContextDB();
        }
        public UsuarioADM(ContextDB db)
        {
            this.db = db;
        }

        public Usuario validarUsuario(String usuario,String password) {

            password = SeguridadADM.EncodePassword(password);
            Usuario usuarioCTX = db.Usuarios.SingleOrDefault(u => string.Equals(u.mail, usuario) && string.Equals(u.password, password));
            if (usuarioCTX == null)
                throw new Exception("Usuario y/o Contraseña invalida");
            return usuarioCTX;

        }

        public void registrarUsuario(Usuario usuario)
        {
            usuario.fecha_alta = DateTime.Now;
            usuario.password=SeguridadADM.EncodePassword(usuario.password);
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }



    }
}
