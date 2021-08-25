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