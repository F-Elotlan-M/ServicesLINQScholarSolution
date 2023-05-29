using ServicesLINQScholar.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicesLINQScholar
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public List<usuario> obtenerUsuarios() { 
        }
            List<usuario> UsuariosBD = AlumnoDAO.obtenerUsuarios();
            return usuariosBD;
        {

        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Mensaje iniciarSesion2(string nombreUsuario, string password)
        {
            return AlumnoDAO.iniciarSesion2(nombreUsuario, password);
        }

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public bool EditarUsuario(usuario UsuarioEdicion)
        {
            return AlumnoDAO.editarUsuario(UsuarioEdicion);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
