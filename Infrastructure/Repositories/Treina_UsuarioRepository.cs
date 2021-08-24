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
                                    .Where(x => x.Nome == nome)
                                    .ToListAsync();
            return obj.FirstOrDefault();
                                    
        }
    }
}