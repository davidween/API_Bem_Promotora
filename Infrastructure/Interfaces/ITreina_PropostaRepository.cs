using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_PropostaRepository
    {
        Task<(Treina_Cliente, Treina_Proposta)> Create(Treina_Cliente treina_Cliente, Treina_Proposta treina_Proposta);

        Task<Treina_Proposta> GetByCpf(string cpf);

        Task<List<PageListView>> GetAll(string usuario);

        Task<(Treina_Cliente, Treina_Proposta)> Update(Treina_Cliente treina_Cliente, Treina_Proposta treina_Proposta);
        Task<decimal?> GerarKeyProposta();
    }
}