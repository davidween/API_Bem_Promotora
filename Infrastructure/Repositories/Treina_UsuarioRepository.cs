using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Treina_UsuarioRepository : ITreina_UsuarioRepository
    {
        private readonly ManagerContext _context;

        public Treina_UsuarioRepository(ManagerContext context)
        {
            _context = context;
        }
        public virtual async Task<Treina_Usuario> GetByNome(string nome)
        {
            var obj = await _context.Set<Treina_Usuario>()
                                    .AsNoTracking()
                                    .Where(x => x.Usuario == nome)
                                    .ToListAsync();
            return obj.FirstOrDefault();
                                    
        }

        public virtual async Task<string> Auth(Treina_Usuario treina_Usuario)
        {
            var obj = await _context.Set<Treina_Usuario>()
                                    .AsNoTracking()
                                    .Where(x => x.Usuario == treina_Usuario.Usuario)
                                    .Select(x => new { Resposta = ManagerContext.AutenticarUsuario(treina_Usuario.Usuario, treina_Usuario.Senha) })
                                    .ToListAsync();
            if(obj.Count == 0)
            {
                return  "Usuário ou Senha incorretos!!!";
            }

            else
            {
                return obj.FirstOrDefault().Resposta; 
            }                  
        }
    }
}