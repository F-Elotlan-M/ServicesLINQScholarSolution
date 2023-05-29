using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;

namespace ServicesLINQScholar.Modelo
{
    public static class AlumnoDAO
    {
        /*
         *
         */
        public static List<usuario> obtenerUsuarios()
        {
            //Permite la conexion
            DataClassesEscolarUVDataContext conexionBD = new DataClassesEscolarUVDataContext("escolaruvConnectionString");
            new DataClassesEscolarUVDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDEscolarUV"].ConnectionString);

            //Todos los elementos de la tabla usuarios
            //var crea un elemento que no tiene tipo de dato hasta que se le asigna uno en momento de ejecucion
            //No lleva where porque no hay condicionante, se requiere todos los registros
            IQueryable<usuario> usuario = from usuarioQuery in conexionBD.usuario select usuarioQuery;

            //IQueryble es un componente de LINQ, debe transformarse a list
            //Se puede hacer en el servicio, pero no por buenas practicas
            return usuario.ToList();
        }

        //TODO
        public static void iniciarSesion()
        {
            DataClassesEscolarUVDataContext conexionDB =
               new DataClassesEscolarUVDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDEscolarUV"].ConnectionString);

            var usuarioEncontrado = (From userLogin in conexionDB usuario
                where userLogin.username == UserNamePasswordClientCredential &&
                userLogin.password == password
                select userLogin).FirstOrDefault(); //se usa cuando no se sabe si va a regresar algo
            return usuario;
        }

        public static Boolean guardarUsuario(usuario UsuarioNuevo)
        {
            try 
            {
                DataClassesEscolarUVDataContext conexionDB =
                new DataClassesEscolarUVDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDEscolarUV"].ConnectionString);

                var usuario = new usuario()
                {
                    nombre = UsuarioNuevo.nombre,
                    apellidoPaterno = UsuarioNuevo.apellidoPaterno,
                    apellidoMaterno = UsuarioNuevo.apellidoMaterno,
                    username = UsuarioNuevo.username,
                    password = UsuarioNuevo.password
                };
                conexionDB.usuario.InsertOnSubmit(usuario);
                conexionDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean editarUsuario(usuario UsuarioEdicion)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionDB =
                    new DataClassesEscolarUVDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDEscolarUV"].ConnectionString);

                var usuario = (from usuarioEdicion in conexionDB.usuario
                               where usuarioEdicion.idUsuario == usuarioEdicion.idUsuario
                               select usuarioEdicion).FirstOrDefault();
                if (usuario != null)
                {
                    usuario.nombre = UsuarioEdicion.nombre;
                    return true;
                }
                else { return false; }
            }
            catch (Exception e) 
            { 
                
            }
        }

        public static Mensaje iniciarSesion2(string nombreUsuario, string password)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = new DataClassesEscolarUVDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDEscolarUV"].ConnectionString);
                var usuario = (from usuarioQ in conexionBD.usuario where usuarioQ.username == nombreUsuario && usuarioQ.password == password select usuarioQ).FirstOrDefault();
                return new Mensaje() { error = false, mensaje = "Usuario admitido.", usuarioLogin = usuario };
            }
            catch (Exception ex)
            {
                return new Mensaje() { error = true, mensaje = "Usuario no admitido.", usuarioLogin = null };
            }

        }


    }
}