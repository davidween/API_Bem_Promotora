using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Treina_ClienteRepository : ITreina_ClienteRepository
    {
        private readonly ManagerContext _context;

        public Treina_ClienteRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<Treina_Cliente> Create(Treina_Cliente treina_Cliente)
        {
            _context.Add(treina_Cliente);  // Adicionamos a entidade ao context

            await _context.SaveChangesAsync();

            return treina_Cliente;
        }

        public async Task<Treina_Cliente> GetByCpf(string cpf)
        {
            var treina_Cliente = await _context.TREINA_CLIENTES
                                     .Where(x => x.Cpf.ToUpper() == cpf.ToUpper())
                                     .AsNoTracking()
                                     .ToListAsync();

            return treina_Cliente.FirstOrDefault();
        }
    }
}