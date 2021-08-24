using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Treina_ConveniadaRepository : ITreina_ConveniadaRepository
    {
        private readonly ManagerContext _context;

        public Treina_ConveniadaRepository(ManagerContext context)
        {
            _context = context;
        }
        public async Task<string> GetByDescricao(string descricao)
        {
            var obj = await _context.TREINA_CONVENIADAS
                                    .Where(x => x.Descricao == descricao)
                                    .AsNoTracking()
                                    .ToListAsync();
            if(obj.Count <= 0)
            {
                return null;
            }

            else
            {
                return obj.FirstOrDefault().Conveniada;
            } 
        }
    }
}