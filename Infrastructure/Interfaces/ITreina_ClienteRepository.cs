using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_ClienteRepository
    {
        Task<Treina_Cliente> GetByCpf(string cpf);
        
    }
}