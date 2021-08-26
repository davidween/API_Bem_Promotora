using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_PropostaRepository
    {
        Task<CompositeObject> Create(CompositeObject compositeObject);

        Task<Treina_Proposta> GetByCpf(string cpf);

        Task<List<CompositeObject>> GetAll(string usuario);
    }
}