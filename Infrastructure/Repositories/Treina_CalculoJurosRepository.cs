using System.Threading.Tasks;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Treina_CalculoJurosRepository : ITreina_CalculoJurosRepository
    {
        private readonly ManagerContext _context;

        public Treina_CalculoJurosRepository(ManagerContext context)
        {
            _context = context;
        }

        public async Task<decimal> Get(decimal Vlr_Solicitado, decimal Prazo)
        {
            var obj = await _context.TREINA_CALCULOJUROS
                                    .AsNoTracking()
                                    .ToListAsync();

            return obj[0].Vlr_Juros;
        }
    }
}