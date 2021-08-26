using System;
using System.Linq;
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

            /*    
            A = P * (1 + i) ^ t

            Para entender melhor a formula segue a explicação de cada variável:

                A = Valor final ou seja o resultado que você terá;
                P = Valor inicial que depositado;
                i = Taxa de juros;
                t = É o tempo do investimento.
            */

            var Vlr_Financiado = (double)Vlr_Solicitado * Math.Pow((double)(1 + obj[0].Vlr_Juros), (double)Prazo);

            return (decimal)Math.Round(Vlr_Financiado, 2);
        }
    }
}