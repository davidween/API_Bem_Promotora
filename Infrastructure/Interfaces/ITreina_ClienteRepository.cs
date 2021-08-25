using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_ClienteRepository
    {
        Task<Treina_Cliente> GetByCpf(string cpf);
        
    }
}