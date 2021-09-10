using System.Threading.Tasks;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface IViaCepService
    {
        Task<EnderecoDTO> RecuperarEnderecoPorCep(string cep);
    }
}