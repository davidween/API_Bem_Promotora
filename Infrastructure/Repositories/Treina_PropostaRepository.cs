using System.Collections.Generic;
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

        public virtual async Task<CompositeObject> Create(CompositeObject compositeObject)
        {
            _context.Add(compositeObject.treina_Cliente);  // Adicionamos a entidade ao context
            _context.Add(compositeObject.treina_Proposta);  // Adicionamos a entidade ao context

            await _context.SaveChangesAsync();

            return compositeObject;
        }

        public async Task<Treina_Proposta> GetByCpf(string cpf)
        {
            var treina_Proposta = await _context.TREINA_PROPOSTAS
                                     .Where(x => x.Cpf == cpf)
                                     .AsNoTracking()
                                     .ToListAsync();

            return treina_Proposta.FirstOrDefault();
        }

         public virtual async Task<List<CompositeObject>> GetAll(string usuario){
             
             var allTreina_Proposta = await _context.TREINA_PROPOSTAS
                                                   .Where(p => p.Usuario.ToUpper() == usuario.ToUpper())
                                                   .OrderBy(p => p.Cpf)
                                                   .AsNoTracking()
                                                   .ToListAsync();

            var allTreina_Cliente = await _context.TREINA_CLIENTES
                                                  //.Where(c => _context.TREINA_PROPOSTAS.Any(p => p.Usuario == usuario))
                                                  //.Where(c => c.Cpf == _context.TREINA_PROPOSTAS.Select(p => p.Usuario.ToUpper() == usuario.ToUpper()))
                                                  .Where(c => _context.TREINA_PROPOSTAS.Any(p => p.Usuario == usuario && p.Cpf == c.Cpf))
                                                  .OrderBy(c => c.Cpf)
                                                  .AsNoTracking()
                                                  .ToListAsync();

            var allCompositeObject = new List<CompositeObject>();

            for(int i = 0; i < allTreina_Cliente.Count; i++)
            {
                var treina_Cliente = allTreina_Cliente[i];
                var treina_Proposta = allTreina_Proposta[i];
                
                CompositeObject compositeObject = new CompositeObject(treina_Cliente, treina_Proposta);
                
                allCompositeObject.Add(compositeObject);
            }

            return allCompositeObject;
        }

        public virtual async Task<CompositeObject> Update(CompositeObject compositeObject)
        {
            _context.Entry(compositeObject.treina_Cliente).State = EntityState.Modified;  // Adicionamos a entidade ao context
            _context.Entry(compositeObject.treina_Proposta).State = EntityState.Modified;  // Adicionamos a entidade ao context

            await _context.SaveChangesAsync();

            return compositeObject;
        }
    }
}