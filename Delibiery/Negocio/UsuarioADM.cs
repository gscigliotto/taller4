
using Datos;
using Entities;
using System;
using System.Collections.Generic;
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
            Usuario usuarioCTX = db.Usuarios.Include("roles").SingleOrDefault(u => string.Equals(u.mail, usuario) && string.Equals(u.password, password));
            if (usuarioCTX == null)
                throw new Exception("Usuario y/o Contraseña invalida");
            return usuarioCTX;

        }

        public void registrarUsuario(Usuario usuario)
        {
            usuario.fecha_alta = DateTime.Now;
            string tempPass = usuario.password;
            usuario.password=SeguridadADM.EncodePassword(usuario.password);
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            List<string> destinatarios = new List<string>();
            destinatarios.Add(usuario.mail);
            String body = String.Format("Bienvenido {0}, se genero su usuario {1}, recuerde que su password es: {2}, Salua Atte. Equipo delibiery MSMM", usuario.nombre,usuario.mail, tempPass);
            SeguridadADM.SendMailSinConfig(destinatarios,"Creación de usuario",body);


        }
  



    }
}
