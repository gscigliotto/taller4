
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
        public Usuario buscarUsuario(int id)
        {
            Usuario usuarioCTX = db.Usuarios.Include("Roles").SingleOrDefault(u => u.Id == id);
            if (usuarioCTX == null)
                throw new Exception("Usuario no existe");
            return usuarioCTX;

        }

        public Usuario validarUsuario(String usuario,String password) {

            password = SeguridadADM.EncodePassword(password);
            Usuario usuarioCTX = db.Usuarios.Include("Roles").SingleOrDefault(u => string.Equals(u.Mail, usuario) && string.Equals(u.Password, password));
            if (usuarioCTX == null)
                throw new Exception("Usuario y/o Contraseña invalida");
            return usuarioCTX;

        }

        public void registrarUsuario(Usuario usuario)
        {
            usuario.FechaAlta = DateTime.Now;
            string tempPass = usuario.Password;
            usuario.Password=SeguridadADM.EncodePassword(usuario.Password);
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            List<string> destinatarios = new List<string>();
            destinatarios.Add(usuario.Mail);
            String body = String.Format("Bienvenido {0}, se genero su usuario {1}, recuerde que su password es: {2}, Salua Atte. Equipo delibiery MSMM", usuario.Nombre,usuario.Mail, tempPass);
            SeguridadADM.SendMailSinConfig(destinatarios,"Creación de usuario",body);


        }

        public List<Usuario> obtenerUsuarios()
        {
            return db.Usuarios.ToList();


        }

        public List<Usuario> obtenerUsuarios(int cantidad, int pagina)
        {
            return db.Usuarios.ToList().Skip(pagina-1*cantidad).Take(pagina).ToList();


        }
        public void actualizarRolUsuario(Usuario usuario, List<Rol> roles) {


            var result = db.Usuarios.SingleOrDefault(b => b.Id == usuario.Id);
            result.Roles = roles;
            db.SaveChanges();

        }


        public void recueperarPass(int id)
        {
            Usuario usuario = this.buscarUsuario(id);
            List<String> destinatarios = new List<string>();
            destinatarios.Add(usuario.Mail);
            string cuerpo = String.Format("Estimado, se tramito una nueva password de acceso su nueva password  es:{0}", SeguridadADM.CrearPassword(6));
            SeguridadADM.SendMailSinConfig(destinatarios, "Recupero de Contraseña", cuerpo);

        }



        public void recueperarPass(string mail)
        {
            Usuario usuario = db.Usuarios.SingleOrDefault(u => string.Equals(u.Mail, mail));
            recueperarPass(usuario.Id);
        }

        public void borrarUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
        }
    }
}
