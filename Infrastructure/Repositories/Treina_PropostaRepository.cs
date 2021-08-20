using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Treina_PropostaRepository : ITreina_PropostaRepository
    {
        private readonly ManagerContext _context;

        public Treina_PropostaRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<Treina_Proposta> Create(Treina_Proposta treina_Proposta)
        {
            _context.Add(treina_Proposta);  // Adicionamos a entidade ao context

            await _context.SaveChangesAsync();

            return treina_Proposta;
        }

        public async Task<Treina_Proposta> GetByCpf(string cpf)
        {
            var treina_Proposta = await _context.TREINA_PROPOSTAS
                                     .Where(x => x.Cpf.ToUpper() == cpf.ToUpper())
                                     .AsNoTracking()
                                     .ToListAsync();

            return treina_Proposta.FirstOrDefault();
        }
    }
}