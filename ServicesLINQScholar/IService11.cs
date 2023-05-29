using ServicesLINQScholar.Modelo;
using System.Collections.Generic;

namespace ServicesLINQScholar
{
    public interface IService11
    {
        bool EditarUsuario(usuario UsuarioEdicion);
        bool EliminarUsuario(int idUsuario);
        CompositeType GetDataUsingDataContract(CompositeType composite);
        List<usuario> obtenerUsuarios();
    }
}