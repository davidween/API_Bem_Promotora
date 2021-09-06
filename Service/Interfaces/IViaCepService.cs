using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface IViaCepService
    {
        Task<Endereco> RecuperarEnderecoPorCep(string cep);
    }
}