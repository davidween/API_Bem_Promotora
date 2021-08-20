using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_PropostaRepository
    {
        Task<Treina_Proposta> Create(Treina_Proposta treina_Proposta);

        Task<Treina_Proposta> GetByCpf(string cpf);
    }
}