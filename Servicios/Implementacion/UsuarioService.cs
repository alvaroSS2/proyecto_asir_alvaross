using Microsoft.EntityFrameworkCore;
using ProyectoAlvaro.Models;
using ProyectoAlvaro.Servicios.Contrato;

namespace ProyectoAlvaro.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbproyectoContext _dbContext;

        public UsuarioService(DbproyectoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();
            return usuario_encontrado;
        }
        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
