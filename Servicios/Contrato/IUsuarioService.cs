using Microsoft.EntityFrameworkCore;
using ProyectoAlvaro.Models;

namespace ProyectoAlvaro.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
